using Microsoft.AspNetCore.Mvc;

namespace Bookshop___The_Reader.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
