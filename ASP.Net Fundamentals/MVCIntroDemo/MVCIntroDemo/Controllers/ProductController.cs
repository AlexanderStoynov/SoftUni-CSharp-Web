using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models;
using System.Text;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },


             new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },

             new ProductViewModel()
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            },

        };
        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult ById(int id)
        {
            var model = _products.FirstOrDefault(p => p.Id == id);

			if (model == null)
            {
                TempData["Error"] = "No such product";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

		public IActionResult AllAsJson()
		{
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

			return Json(_products, options);
		}

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _products)
            {
                sb.AppendLine($"Product {item.Id}: {item.Name} - {item.Price} lv.");
            }

            return Content(sb.ToString());
        }

		public IActionResult AllAsTextFile()
        {
			StringBuilder sb = new StringBuilder();
			foreach (var item in _products)
			{
				sb.AppendLine($"Product {item.Id}: {item.Name} - {item.Price} lv.");
			}

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/plain"); 
		}

        public IActionResult Filtered(string? keyword = null)
        {
            if(keyword == null)
            {
                return RedirectToAction(nameof(Index));

            }

            var model = _products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

            return View(nameof(Index), model);
        }
	}
}
