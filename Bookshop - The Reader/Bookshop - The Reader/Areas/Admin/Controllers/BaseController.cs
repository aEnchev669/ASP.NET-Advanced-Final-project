using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Bookshop___The_Reader.Areas.Admin.AdminConstants.AdminConstants;

namespace Bookshop___The_Reader.Areas.Admin.Controllers
{
	[Area(AreaName)]
	[Route(RouteName)]
	//[Authorize(Roles = AdminRoleName)]
	public class BaseController : Controller
	{
	}
}
