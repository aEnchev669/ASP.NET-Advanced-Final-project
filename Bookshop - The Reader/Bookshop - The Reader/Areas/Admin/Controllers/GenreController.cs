using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Book;
using TheReader.Core.Models.Genre;
using static TheReader.Infrastructure.Constants.NotificationMessagesConstants;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
    public class GenreController : BaseController
    {

        private readonly IGenreService genreService;

        public GenreController(IGenreService _genreService)
        {
            genreService = _genreService;
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

            //if (!ModelState.IsValid )
            //{
            //	TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            //	return View(genreModel);
            //}

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
            return RedirectToAction("Genre", "All");
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //	var categoryList = categoryService.AllCategories()
        //		.Where(x => x.Type != SubCategory);
        //	var model = new GenreViewModel()
        //	{
        //		ParentCategories = categoryList
        //	};
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewGenreViewModel genreModel)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            return RedirectToAction("Genre", "Admin");
        }
    }
}
