using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

using jannieCouture.Services;
using jannieCouture.ViewModels;
using jannieCouture.Models;
using jannieCouture.Repositories;


namespace jannieCouture.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _configuration;
        private ILogger<AccountController> _logger;
        private IEmailSender _emailSender;
        private AppDbContext _appDbContext;
        private IUserCategoryRespository _userCategoryRepository;

		public AccountController(
		    UserManager<IdentityUser> userManager,
		    SignInManager<IdentityUser> signInManager,
		    IConfiguration configuration,
		    ILogger<AccountController> logger,
            IEmailSender emailSender,
            AppDbContext appDbContext,
            IUserCategoryRespository userCategoryRepository
		   )
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
            _logger = logger;
            _emailSender = emailSender;
            _appDbContext = appDbContext;
            _userCategoryRepository = userCategoryRepository;
		}

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var user = _appDbContext.ApplicationUser
									 .Where(u => u.Email == model.Email).SingleOrDefault();
				if (user == null)
				{
					return StatusCode(401, "Wrong email or password");
				}
				else if (!user.EmailConfirmed)
				{
					return StatusCode(401, "You have not confirmed your email yet, please do that then login");
				}

                Console.WriteLine("---> user password {0}- {1}", model.Password, model.Email);
                var result = await _signInManager.PasswordSignInAsync(user.NormalizedUserName, model.Password, false, false);

				if (result.Succeeded)
				{
					var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
					var response = new
					{
						jwt = await GenerateJwtToken(appUser.Email, appUser),
						userName = appUser.UserName,
					};
					return StatusCode(200, response);
                } else if (result.IsLockedOut || result.IsNotAllowed) {
                   return StatusCode(401, "Your account was disable, please send a mail to our helpdesk");
                }else {
					return StatusCode(401, "Wrong email or password");
				}
            }
			catch (Exception ex)
			{
                string SupportEmail = _configuration["SupportEmail"];
				_logger.LogError($"An error occurred during login user {DateTime.UtcNow}, error_message - {ex}");
				string ResponseText = string.Format("An error occured, please try again or send us a mail {0}", SupportEmail);
				return StatusCode(500, ResponseText);
			}

        }
		[HttpPost]
		[AllowAnonymous]
		public async Task<object> Register([FromBody] RegisterViewModel model)
		{
			var user = new ApplicationUser
			{
				UserName = model.UserName,
				Email = model.Email,
                UserCategory = _userCategoryRepository
                    .UserCategories.FirstOrDefault(uc => uc.Name == "shopper")

			};
            try
            {
				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
					 _emailSender.SendEmailAsync(model.Email, "Confirm your account",
						$"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    return StatusCode(200, "Well done, please check your mail and verifiy your account");
                    // await _signInManager.SignInAsync(user, false);
					//return await GenerateJwtToken(model.Email, user);
				}
                return StatusCode(400, "Please check your request and try again");

            }
            catch (Exception ex)
            {
                string SupportEmail = _configuration["SupportEmail"];
                _logger.LogError($"An error occurred while registering user {DateTime.UtcNow}, error_message - {ex}");
                string ResponseText = string.Format("An error occured, please try again or send us a mail {0}", SupportEmail);
                return StatusCode(500, ResponseText);
            }
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
                var user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View("ForgotPasswordConfirmation");
				}

				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
				// Send an email with this link
				var code = await _userManager.GeneratePasswordResetTokenAsync(user);
				var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
				_emailSender.SendEmailAsync(model.Email, "Reset Password",
				   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");
				return View("ForgotPasswordConfirmation");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

        [HttpGet]
		[AllowAnonymous]
        public async Task<object> ConfirmEmailAPI(string userId, string code)
		{
            string SupportEmail = _configuration["SupportEmail"];
			if (userId == null || code == null)
			{
				return StatusCode(400, "Invalid Request, please request to a confirmation link");
			}
			IdentityResult result;
            var appUser = _userManager.Users.SingleOrDefault(u => u.Id == userId);
			try
			{
                result = await _userManager.ConfirmEmailAsync(appUser, code);

                var user = new IdentityUser
                {
                    UserName = appUser.Email,
                    Email = appUser.Email
                };
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(appUser, false);
                    var response = new
                    {
                        jwt = await GenerateJwtToken(user.Email, user),
                        UserName = appUser.UserName,
                    };
                    return StatusCode(201, response);
				}
                return StatusCode(400, "We were unable to verify your account, we recommend that you request for a new account confirmation mail. We sincerely apologize for this incident"); 
			}
			catch (InvalidOperationException ioe)
			{
				_logger.LogError($"An error occurred white registering user {DateTime.UtcNow}, error_message - {ioe}");
				string ResponseText = string.Format("An error occured, The userid does not exist. Reach to us if you need help {0}", SupportEmail);
				return StatusCode(500, ResponseText);
			}
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<object> ResetPassword(string userId, string code)
		{
			string SupportEmail = _configuration["SupportEmail"];
			if (userId == null || code == null)
			{
				return StatusCode(400, "Invalid Request, please request to a confirmation link");
			}
			IdentityResult result;
			var appUser = _userManager.Users.SingleOrDefault(u => u.Id == userId);
			try
			{
				result = await _userManager.ConfirmEmailAsync(appUser, code);

				var user = new IdentityUser
				{
					UserName = appUser.Email,
					Email = appUser.Email
				};
				if (result.Succeeded)
				{
                    await _signInManager.SignInAsync(appUser, false);
					var response = new
					{
						jwt = await GenerateJwtToken(user.Email, user),
                        UserName = appUser.UserName,
					};
					return StatusCode(200, response);
				}
				return StatusCode(400, "We were unable to verify your account, we recommend that you request for a new account confirmation mail. We sincerely apologize for this incident");
			}
			catch (InvalidOperationException ioe)
			{
				_logger.LogError($"An error occurred white registering user {DateTime.UtcNow}, error_message - {ioe}");
				string ResponseText = string.Format("An error occured, The userid does not exist. Reach to us if you need help {0}", SupportEmail);
				return StatusCode(500, ResponseText);
			}
		}

		private  async Task<object> GenerateJwtToken(string email, IdentityUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

			var token = new JwtSecurityToken(
				_configuration["JwtIssuer"],
				_configuration["JwtIssuer"],
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
