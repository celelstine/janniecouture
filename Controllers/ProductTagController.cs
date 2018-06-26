using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using jannieCouture.Models;
using jannieCouture.Repositories;
using jannieCouture.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jannieCouture.Controllers
{
    [Route("api/ProductTag")]
    public class ProductTagController : Controller
    {
		private IProductTagRepository _productTagRepository;
		private ILogger<ProductTagController> _logger;

        public ProductTagController(
			IProductTagRepository productTagRepository,
			ILogger<ProductTagController> logger
        )
        {
            _productTagRepository = productTagRepository;
            _logger = logger;
        }
        // GET: /<controller>/
        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            try
            {
                var ProductTags = _productTagRepository.ProductTags;
                return Ok(ProductTags);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting ProductTags {DateTime.UtcNow}, error_message - {ex}");
                return StatusCode(500, "Failed to get Product Tags.");
            }
        }

		[HttpPost("")]
        [AllowAnonymous]
        public IActionResult IndexAddProductTag([FromBody] ProductTagViewModel model)
		{
            
			try
			{
                ProductTag newProductTag = new ProductTag();
                newProductTag.Name = model.Name;
                newProductTag.Description = model.Description;
                _productTagRepository.AddProductTag(newProductTag);
                return Ok(newProductTag);
			}
			catch (Exception ex)
			{
				_logger.LogError($"An error occurred while adding ProductTag {DateTime.UtcNow}, error_message - {ex}");
				return StatusCode(500, "Failed to add Product Tags.");
			}
		}
    }
}
