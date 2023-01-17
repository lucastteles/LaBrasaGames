using LaBrasa.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace LaBrasa.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }
         
        [HttpGet] 
        public IActionResult Login(string returnUrl)
        {
            return View(new LOn;
        }
    }
}
