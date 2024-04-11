using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;

namespace Bookshop___The_Reader.Controllers
{
    public class GenreController : Controller
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;

        public GenreController(IBookService _bookService, IGenreService _genreService)
        {
            bookService = _bookService;
            genreService = _genreService;
        }
        public async Task<IActionResult> All()
        {
            var genres = await genreService.AllGenresAsync();

            if (genres == null)
            {
                return View();
            }
            return View(genres);
        }

        public async Task<IActionResult> Books(string name)
        {
            try
            {
                var items = await bookService.AllIBooksByChoosenGenreAsync(name);

                return View(items);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

