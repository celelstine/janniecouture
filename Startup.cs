using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.Webpack;
using jannieCouture.Models;
using jannieCouture.Repositories;
using jannieCouture.Services;

namespace jannieCouture
{
    public class Startup
    {
        
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath);
            
			//if (env.IsDevelopment())
			//{
   //             builder.AddJsonFile("appsettings.Development.json");
			//}
			//else
			//{
				builder.AddJsonFile("appsettings.json");
			//}
            builder.AddEnvironmentVariables();
            _config = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddSingleton(_config);
			var connectionString = _config.GetConnectionString("DefaultConnection");
			services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
			// addTransient: one per invokation
			// addSingleton: one for all
			// addScoped : one instance per http request
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
			   .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // handle jwt authentication
            // we first remove default claims services
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = _config["JwtIssuer"],
						ValidAudience = _config["JwtIssuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtKey"])),
						ClockSkew = TimeSpan.Zero // remove delay of token when expire
					};
                });

            services.AddTransient<IAgeRangeRepository, AgeRangeRepository>();
            services.AddTransient<IProductTagRepository, ProductTagRepository>();
			services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserCategoryRespository, UserCategoryRespository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSingleton<IEmailSender, EmailSender>();

            services.Configure<AuthMessageSenderOptions>(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                //  for webpack hot reload
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
			//app.UseSession();
			app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                // we use this to fallback to the index route when no route is found
                routes.MapSpaFallbackRoute(
                    "spa-fallback",
                    new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
