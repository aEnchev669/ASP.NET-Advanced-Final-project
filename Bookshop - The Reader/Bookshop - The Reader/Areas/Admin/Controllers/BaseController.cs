using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin, Moderator")]
	public class BaseController : Controller
	{
	}
}
