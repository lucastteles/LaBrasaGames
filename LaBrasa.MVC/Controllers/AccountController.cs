using Microsoft.AspNetCore.Mvc;

namespace LaBrasa.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
