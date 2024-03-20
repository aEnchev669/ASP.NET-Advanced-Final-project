using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Models.Genre;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
	public class GenreController : BaseController
	{
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(NewGenreViewModel genreModel)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			return View();
		}

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
			return View();
		}
	}
}
