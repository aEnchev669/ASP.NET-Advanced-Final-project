using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Models.Book;

namespace Bookshop___The_Reader.Controllers
{
	[Authorize]
	public class BookController : Controller
	{
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			var model = new AllBooksViewModel();
			return View(model);
		}
		public async Task<IActionResult> Favourites()
		{
			var model = new AllBooksViewModel();
			return View(model);
		}

		public async Task<IActionResult> Details(int id)
		{
			var model = new BooksDetailsViewModel();
			return View(model);
		}
		public async Task<IActionResult> Reviews(int id)
		{
			var model = new BooksDetailsViewModel();
			return View(model);
		}
		private IActionResult GeneralErrorMessage()
		{
			
			return View();
		}
	}
}
