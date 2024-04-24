using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;

namespace BookshopTheReader.Controllers
{
	public class HomeController : Controller
	{

		private readonly IBookService bookService;

		public HomeController(
			ILogger<HomeController> logger,
			IBookService _bookService)
		{

			bookService = _bookService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var model = await bookService.LastFourBooksAsync();

			return View(model);
		}

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 400)
			{
				return View("Error400");
			}
			if (statusCode == 401)
			{
				return View("Error401");
			}
			if (statusCode == 404)
			{
				return View("Error404");
			}
			if (statusCode == 500)
			{
				return View("Error500");
			}

			return View("Error");
		}
	}
}