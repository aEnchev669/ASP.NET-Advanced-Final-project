using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop___The_Reader.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Cart()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(int id)
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Remove(int id)
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Increase(int id)
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Decrease(int id)
		{
			return View();
		}
		private IActionResult GeneralErrorMessage()
		{
			return View();
		}
	}
}
