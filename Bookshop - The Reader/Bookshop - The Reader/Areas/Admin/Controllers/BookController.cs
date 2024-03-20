using Microsoft.AspNetCore.Mvc;
using TheReader.Core.Models.Book;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
	public class BookController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(BookFormViewModel itemModel)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
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

		private IActionResult GeneralErrorMessage()
		{
			return View();
		}
	}
}
