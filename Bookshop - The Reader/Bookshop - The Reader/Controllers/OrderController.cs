using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Models.Order;

namespace Bookshop___The_Reader.Controllers
{
	public class OrderController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Checkout()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(OrderFormViewModel order)
		{
			return View(order);
		}

		[HttpGet]
		public IActionResult Confirmed()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> OrderHistory()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetails(string id)
		{
			return View();
		}
	}
}
