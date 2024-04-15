using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Genre;
using static TheReader.Infrastructure.Constants.NotificationMessagesConstants;
using TheReader.Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using TheReader.Core.Contracts.Genre;

namespace Bookshop___The_Reader.Controllers
{
	[Authorize]
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
			
				var items = await bookService.AllIBooksByChoosenGenreAsync(name);

				return View(items);
		
			
		}

		
		[HttpGet]
		public IActionResult Add()
		{
			var genreModel = new NewGenreViewModel();

			return View(genreModel);
		}

		
		[HttpPost]
		public async Task<IActionResult> Add(NewGenreViewModel genreModel)
		{
			bool isGenreExist = await genreService
				.IsGenreExistByNameAsync(genreModel.Name);

			if (isGenreExist)
			{
				ModelState.AddModelError(nameof(genreModel.Name), "This Genre already exist");
			}

			if (!ModelState.IsValid)
			{
				TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

				return View(genreModel);
			}

			try
			{
				await genreService.CreateNewGenreAsync(genreModel);
			}
			catch (Exception)
			{
				TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

				return View(genreModel);
			}

			TempData[SuccessMessage] = "Your new genre have been added successfully.";
			return RedirectToAction("All", "Genre");
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{

			if (!await genreService.IsGenreExistAsync(id))
			{
				return BadRequest();
			}

			var searchedGenre = genreService.DeleteGenreAsync(id);

			return View(searchedGenre);
		}
		[HttpPost]

		public async Task<IActionResult> DeleteConfirmed(int id)
		{

			if (!await genreService.IsGenreExistAsync(id))
			{
				return BadRequest();
			}
			await genreService.DeleteGenreConfirmAsync(id);

			return RedirectToAction("All", "Genre");
		}

		private IActionResult GeneralErrorMessage()
		{
			TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

			return RedirectToAction("All", "Genre");
		}
	}
}

