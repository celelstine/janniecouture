using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Core;
using CloudinaryDotNet.Actions;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jannieCouture.Controllers
{
    public class AdminProductController : Controller
    {

        static Cloudinary cloudinary;
        public AdminProductController () {

            Account account = new Account(
              "celestine",
              "381232645994128",
              "f0HJ2TvgV2cvmK0DkJXhQVlhLuk");

            cloudinary = new Cloudinary(account);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(cloudinary);
        }

		[HttpPost]
		public IActionResult UploadServer() 
        {
            for (int i = 0; i < HttpContext.Request.Form.Files.Count; i++)
            {
				var file = HttpContext.Request.Form.Files[i];

				var result = cloudinary.Upload(new ImageUploadParams()
				{
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
					Tags = "backend_photo_album"
				});
				foreach (var token in result.JsonObj.Children())
				{
					if (token is JProperty)
					{
						JProperty prop = (JProperty)token;
						Console.Write(prop.Name + "-->" +prop.Value.ToString());
					}
				}
            }

            return View("index", cloudinary);
        }
    }
}
