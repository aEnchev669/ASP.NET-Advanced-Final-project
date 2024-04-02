using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;

namespace BookshopTheReader.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IBookService bookService;

		public HomeController(
			ILogger<HomeController> logger,
			IBookService _bookService)
		{
			_logger = logger;
			bookService = _bookService;
		}

		public async Task<IActionResult> Index()
		{
			var model = await bookService.LastFourBooksAsync();

			return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> Error(int statusCode)
		{
			return View("Error");
		}
	}
}