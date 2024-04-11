using BookshopTheReader.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Book;
using TheReader.Infrastructure.Data.Models.Books;
using static TheReader.Infrastructure.Constants.NotificationMessagesConstants;
namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly TheReaderDbContext dbContext;
        public BookController(IBookService _bookService, IGenreService _genreService)
        {
            bookService = _bookService;
            genreService = _genreService;
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var bookModel = new BookFormViewModel();
            bookModel
            return View(bookModel);

        }
        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel bookModel)
        {
            bool isGenreExist = await genreService
                .IsGenreExistByIdAsync(bookModel.GenreId);

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
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookFormViewModel itemModel)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }
        private async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await dbContext.Genres
                .AsNoTracking()
                .Select(t => new Genre
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }
        private IActionResult GeneralErrorMessage()
        {
            return View();
        }

    }
}
