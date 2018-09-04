using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using CloudinaryDotNet;
using CloudinaryDotNet.Core;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json.Linq;
using jannieCouture.Repositories;
using jannieCouture.Models;
using jannieCouture.ViewModels;

namespace jannieCouture.Controllers
{
	[Route("api/Product")]
	public class ProductController : Controller
	{
		private IProductRepository _productRepository;
		private ILogger<ProductController> _logger;
		private readonly IConfiguration _configuration;
		static Cloudinary cloudinary;
		public ProductController(
			ILogger<ProductController> logger,
			IProductRepository productRepository,
			IConfiguration configuration
		)
		{
			_logger = logger;
			_productRepository = productRepository;
            _configuration = configuration;
			Account account = new Account(
			  _configuration["CLOUDINARY_USERNAME"],
			  _configuration["CLOUDINARY_KEY"],
			  _configuration["CLOUDINARY_SECRET"]);

			cloudinary = new Cloudinary(account);
		}

		[HttpGet("{name}")]
		public IActionResult ProductByName(string name)
		{
			try
			{
                Product product = _productRepository
                    .products
					.Where(p => p.Name == name).FirstOrDefault();
				if (product != null)
				{
					return Ok(product);
				}
				return StatusCode(404, "No Product with the name: " + name);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while getting product  {DateTime.UtcNow}, error_message - {ex}");
                return StatusCode(500, $"Failed to get product with name: ${name}.");
			}
		}

		[HttpGet("")]
		public IActionResult Index()
		{
			try
			{
                
				int _size = 10;
                Int32.TryParse(HttpContext.Request.Query["size"].ToString() ?? "10" , out _size);
				if (_size < 1)
				{
					_size = 10;
				}
				int _lastProductIndex = 0;
                Int32.TryParse(HttpContext.Request.Query["lastIndex"].ToString() ?? "0", out _lastProductIndex);
				if (_lastProductIndex < 1)
				{
					_lastProductIndex = 0;
				}
                int _catID = 0;
                Int32.TryParse(HttpContext.Request.Query["catid"].ToString() ?? "0", out _catID);
				if (_catID < 1)
				{
					_catID = 0;
				}
                if ( _catID > 0)
                {
					List<Product> productsByCatID = _productRepository
						.products
                        .Where(p => p.ProductCategoryID == _catID)
						.Skip(_lastProductIndex)
						.Take(_size)
						.ToList();
					return Ok(productsByCatID);
                }
                else
                {
					List<Product> products = _productRepository
                        .products
                        .Skip(_lastProductIndex)
                        .Take(_size)
                        .ToList();
					return Ok(products);
                }
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while getting products {DateTime.UtcNow}, error_message - {ex}");
				return StatusCode(500, "Failed to get products.");
			}
		}

		[HttpPost("")]
		public IActionResult Addproduct([FromForm] ProductViewModel model)
		{
			try
			{
                Product existingProduct = _productRepository
                    .products
                    .Where(p => (p.Name == model.Name) && (p.ProductCategoryID == model.ProductCategoryID))
                    .FirstOrDefault();
                
                if (existingProduct != null){
                    return StatusCode(400, $"A product with name; {existingProduct.Name} exist already in this category");
                } else {
                    Product newProduct = new Product();
                    newProduct.Name = model.Name;
                    newProduct.ProductCategoryID = model.ProductCategoryID;
                    newProduct.Tags = model.Tags[0].Split(','); ;
                    newProduct.PriceCurrent = model.PriceCurrent;
                    Console.WriteLine("model.MarketNames {0}",  model);
                    if (model.MarketNames != null) {
                        newProduct.MarketNames = model.MarketNames[0].Split(',');
                    }

                    newProduct.PriceRange = model.PriceRange;
                    newProduct.MeasurementCategory = model.MeasurementCategory;

					var image = HttpContext.Request.Form.Files[0];
					if (image != null) {
    					var CloudinaryResult = cloudinary.Upload(new ImageUploadParams()
    					{
    						File = new FileDescription(image.FileName, image.OpenReadStream()),
    						Tags = String.Join(" ", model.Tags)
    					});
                        newProduct.ImageUrl = CloudinaryResult.SecureUri.ToString() ?? null;
                    } else {
                        newProduct.ImageUrl = "";
					}
					

                    _productRepository.AddProduct(newProduct);
                    return Ok(newProduct);

                }

			}
			catch (Exception ex)
			{
					_logger.LogError($"An error occurred while adding product  {DateTime.UtcNow}, error_message - {ex}");
					return StatusCode(500, "Failed to add product.");
			}


		}
	}
}
