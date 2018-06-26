using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Core;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json.Linq;
using jannieCouture.Repositories;
using jannieCouture.Models;
using jannieCouture.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jannieCouture.Controllers
{
    [Route("api/ProductCategory")]
    public class ProductCategoryController : Controller
    {
		private IProductCategoryRepository _productCategoryRepository;
        private IProductRepository _productRepository;
		private ILogger<ProductCategoryController> _logger;
        private readonly IConfiguration _configuration;
        private AppDbContext _appDbContext;
        static Cloudinary cloudinary;
        public ProductCategoryController(
            ILogger<ProductCategoryController> logger,
            IProductCategoryRepository productCategoryRepository,
            IProductRepository productRepository,
            IConfiguration configuration,
            AppDbContext appDbContext
        )
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _configuration = configuration;
            _appDbContext = appDbContext;

			Account account = new Account(
			  _configuration["CLOUDINARY_USERNAME"],
			  _configuration["CLOUDINARY_KEY"],
			  _configuration["CLOUDINARY_SECRET"]);

			cloudinary = new Cloudinary(account);
        }

		[HttpGet("{name}/products")]
		public IActionResult CategoryProducts(string name)
		{
			try
			{
				ProductCategory productCategory = _appDbContext
				   .ProductCategory
				   .Where(pc => pc.Name == name).FirstOrDefault();
				if (productCategory != null)
				{
					int _lastProductIndex = 0;
					Int32.TryParse(HttpContext.Request.Query["lastIndex"].ToString() ?? "0", out _lastProductIndex);
                    if (_lastProductIndex < 1)
                    {
                        _lastProductIndex = 0;
                    }

					int _size = 10;
					Int32.TryParse(HttpContext.Request.Query["size"].ToString() ?? "10", out _size);
					if (_size < 1)
					{
						_size = 10;
					}
					List<Product> products = _productRepository
						.products
                        .Where(p => p.ProductCategoryID == productCategory.ProductCategoryID)
						.Skip(_lastProductIndex)
						.Take(_size)
						.ToList();
					return Ok(products);
				}
				return StatusCode(404, "No Category with the name: " + name);
				
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while getting products by Category {DateTime.UtcNow}, error_message - {ex}");
				return StatusCode(500, "Failed to get products by Category.");
			}
		}

		[HttpGet("{name}")]
        public IActionResult CategoryByName(string name)
        {
            try
            {
                ProductCategory productCategory = _appDbContext
                    .ProductCategory
                    .Where(pc => pc.Name == name).FirstOrDefault();
                if ( productCategory != null)
                {
                    return Ok(productCategory);
                }
                return StatusCode(404, "No Category with the name: " + name);
            }
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while getting product Category {DateTime.UtcNow}, error_message - {ex}");
				return StatusCode(500, "Failed to get product Category.");
			}
        }
		
		[HttpGet("")]
		public IActionResult Index([FromQuery(Name = "lastIndex")] string lastProductIndex = "0")
		{
			try
			{
				int _lastProductIndex = 0;
				Int32.TryParse(lastProductIndex, out _lastProductIndex);
				if (_lastProductIndex < 1)
				{
					_lastProductIndex = 0;
				}
				int _size = 10;
				Int32.TryParse(HttpContext.Request.Query["size"].ToString() ?? "10", out _size);
				if (_size < 1)
				{
					_size = 10;
				}
                List<ProductCategory> productCategories = _productCategoryRepository
                    .productCategories
                    .Skip(_lastProductIndex)
                    .Take(_size)
                    .ToList();

				// start loading top K comments from each post
				//foreach (var productCategory in productCategories)
				//{

    //                productCategory.Products = _productRepository
    //                    .products
    //                    .Where(p => p.ProductCategoryID == productCategory.ProductCategoryID)
    //                    .Take(4)
    //                    .ToList();
				//}

                return Ok(productCategories);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while getting product Categories {DateTime.UtcNow}, error_message - {ex}");
				return StatusCode(500, "Failed to get product Categories.");
			}
		}

		[HttpPost("")]
        public IActionResult AddProductCategory([FromForm] ProductCategoryViewModel model)
		{

			try
			{
                // check that a product category does not exist with same name
                ProductCategory existingcategory = _productCategoryRepository
                    .productCategories
                    .Where(pc => pc.Name == model.Name)
                    .FirstOrDefault();
                if (existingcategory == null){
                    return StatusCode(400, $"A product Category with name; {model.Name} exist already");
                }
				var file = HttpContext.Request.Form.Files[0];

				var result = cloudinary.Upload(new ImageUploadParams()
				{
					File = new FileDescription(file.FileName, file.OpenReadStream()),
                    Tags = String.Join(" ", model.Tags)
				});

				ProductCategory newProductCategory = new ProductCategory();
				newProductCategory.Name = model.Name;
                newProductCategory.MarketNames = model.MarketNames;
                newProductCategory.Tags = model.Tags;
                newProductCategory.ImageUrl = result.SecureUri.ToString();
                _productCategoryRepository.AddProductCategory(newProductCategory);
				return Ok(newProductCategory);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while adding product Category {DateTime.UtcNow}, error_message - {ex}");
				return StatusCode(500, "Failed to add product Category.");
			}
		}
    }
}
