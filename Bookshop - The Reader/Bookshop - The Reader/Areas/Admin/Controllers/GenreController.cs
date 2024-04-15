using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Contracts.Genre;
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
