using Labrasa.Application.Interfaces;
using LaBrasa.Infra.Data.Identity;
using LaBrasa.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaBrasa.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsuarioService _usuarioService;

        public AdminAccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Usuario()
        {
            var usersIdentity = userManager.Users.ToList();

            var usuarios = await _usuarioService.ObterUsuario();


            var usersVM = new List<UsuarioViewModel>();

            foreach (var user in usersIdentity)
            {
                var usuarioDto = usuarios.FirstOrDefault(x => x.IdIdentity.ToString() == user.Id);

                usersVM.Add(new UsuarioViewModel()
                {
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Nome = usuarioDto?.Nome,
                    Sobrenome = usuarioDto?.Sobrenome,
                    Endereco1 = usuarioDto?.Endereco
                });
            }

            return View(usersVM);
        }



    }
}
