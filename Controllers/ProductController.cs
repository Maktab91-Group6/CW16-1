using CW16.Entity;
using CW16.Service;
using Microsoft.AspNetCore.Mvc;

namespace CW16.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			return View(_productService.GetAll());
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			_productService.Delete(id);
			return RedirectToAction("Index");

		}

		[HttpPost]
		public IActionResult Edit(int id, string name, int quantity, string color, int unitPrice)
		{
			_productService.Edit(id, name, quantity, color, unitPrice);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			return View(_productService.GetById(id));
		}


		[HttpPost]
		public IActionResult Create(Product product)
		{

			_productService.Create(product);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}





	}
}
