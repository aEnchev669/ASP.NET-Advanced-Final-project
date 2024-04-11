using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Book;
using TheReader.Infrastructure.Constants;

namespace Bookshop___The_Reader.Controllers
{
	[Authorize]
	public class BookController : Controller
	{
		private readonly IBookService bookService;
		//private readonly IGenreService genreService;

		public BookController(IBookService _bookService, IGenreService _genreService)
		{
			bookService = _bookService;
			//genreService = _genreService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			var books = await bookService.AllBooksAsync();
			if (books == null)
			{
				return View();
			}
			return View(books);
		}

		public async Task<IActionResult> Details(int id)
		{
			try
			{
				var model = await bookService.GetDetailsByIdAsync(id);

				return View(model);
			}
			catch (ArgumentNullException)
			{
				ModelState.AddModelError("", "Invalid id");
				return View();
			}
			catch (Exception)
			{
				return RedirectToAction("Index", "Home");
			}

		}
		
		private IActionResult GeneralErrorMessage()
		{


			return View();
		}
	}
}
