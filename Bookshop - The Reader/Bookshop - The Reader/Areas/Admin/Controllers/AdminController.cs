using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Models.Book;
using TheReader.Core.Models.Genre;
using TheReader.Core.Models.User;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
	public class AdminController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Items([FromQuery] AllBooksViewModel queryModel)
		{
			return View(queryModel);
		}

		public async Task<IActionResult> Genres([FromQuery] AllGenresViewModel queryModel)
		{
			return View(queryModel);
		}

		public async Task<IActionResult> Users([FromQuery] AllUsersViewModel queryModel)
		{
			return View(queryModel);
		}

		[HttpPost]
		public async Task<IActionResult> SetRole(string userId, bool isModerator)
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Enable(int id)
		{
			return View();
		}

		private IActionResult GeneralErrorMessage()
		{
			return View();
		}

	}
}
