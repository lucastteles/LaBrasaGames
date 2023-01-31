using LaBrasa.Infra.Data.Identity;
using LaBrasa.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LaBrasa.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AdminAccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Usuario()
        {
            var users = userManager.Users.ToList();

            var usersVM = new List<UsuarioViewModel>();

            foreach (var user in users)
            {
                usersVM.Add(new UsuarioViewModel()
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber

                });
            }

            return View(usersVM);
        }



        }
}
