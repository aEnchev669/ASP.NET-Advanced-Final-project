using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Contracts.Genre;
using TheReader.Core.Models.Book;
using static TheReader.Infrastructure.Constants.NotificationMessagesConstants;

namespace Bookshop___The_Reader.Controllers
{
	[Authorize]
	public class BookController : Controller
	{
		private readonly IBookService bookService;
		private readonly IGenreService genreService;


		public BookController(IBookService _bookService, IGenreService _genreService)
		{
			bookService = _bookService;
			genreService = _genreService;
		}

		[Authorize]
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

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult AddBook()
        {

            var bookModel = new BookFormViewModel();
            return View(bookModel);

        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddBook(BookFormViewModel bookModel)
        {
            bool isGenreExist = await genreService
                .IsGenreExistAsync(bookModel.GenreId);

            if (!isGenreExist)
            {
                ModelState.AddModelError(nameof(bookModel.GenreId), "Invalid Genre");
            }

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

                return View(bookModel);
            }


            await bookService.CreateBookAsync(bookModel);


            TempData[SuccessMessage] = "Your book have been added successfully.";
            return Redirect("/Book/All");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currBook = await bookService.GetBookByIdAsync(id);
                return View(currBook);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, BookFormViewModel bookModel)
        {
            bool isCategoryExist = await genreService
                .IsGenreExistAsync(bookModel.GenreId);

            if (!isCategoryExist)
            {
                ModelState.AddModelError(nameof(bookModel.GenreId), "Invalid Genre");
            }

            try
            {
                await bookService.EditBookAsync(id, bookModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited the book successfully.";
            return RedirectToAction("All", "Book");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }

            var searchedBook = bookService.DeleteBookAsync(id);

            return View(searchedBook);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (!await bookService.BookExistsAsync(id))
            {
                return BadRequest();
            }
            await bookService.DeleteBookConfirmAsync(id);

            return RedirectToAction("All", "Book");
        }
        private IActionResult GeneralErrorMessage()
		{
			TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

			return RedirectToAction("All", "Book");
		}
	}
}
