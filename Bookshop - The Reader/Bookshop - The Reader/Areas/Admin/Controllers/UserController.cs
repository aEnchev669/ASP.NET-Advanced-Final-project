using Microsoft.AspNetCore.Mvc;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
	public class UserController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			return View();
		}
	}
}
