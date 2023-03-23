using Labrasa.Application.Interfaces;
using LaBrasa.Infra.Data.Identity;
using LaBrasa.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaBrasa.MVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsuarioService _usuarioService;

        public AdminAccountController(UserManager<ApplicationUser> userManager,
            IUsuarioService usuarioService)
        {
            this.userManager = userManager;
            _usuarioService = usuarioService;
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
                    Idade = usuarioDto?.Idade.ToString(),
                    Sobrenome = usuarioDto?.Sobrenome,
                    Endereco = usuarioDto?.Endereco,
                    Genero = usuarioDto?.Genero.ToString(),
                });
            }

            return View(usersVM);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
          

            if (string.IsNullOrEmpty(searchString))
            {

                var todosUsuarios = await _usuarioService.ObterUsuario();
                var usuariosIdentity = userManager.Users.ToList();

                var usersVM = new List<UsuarioViewModel>();

                foreach (var user in usuariosIdentity)
                {
                    var usuarioDto = todosUsuarios.FirstOrDefault(x => x.IdIdentity.ToString() == user.Id);

                    usersVM.Add(new UsuarioViewModel()
                    {
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Nome = usuarioDto?.Nome,
                        Idade = usuarioDto?.Idade.ToString(),
                        Sobrenome = usuarioDto?.Sobrenome,
                        Endereco = usuarioDto?.Endereco,
                        Genero = usuarioDto?.Genero.ToString(),
                    });
                }

                return View(usersVM);
            }

            else
            {
                var usersIdentity = userManager.Users.Where(p => p.UserName.ToLower()////////******/ 
                     .Contains(searchString.ToLower()));


                var usuarios = await _usuarioService.ObterUsuarioPorNome(searchString);


                var usersViewM = new List<UsuarioViewModel>();

                foreach (var user in usersIdentity)
                {
                    var usuarioDto = usuarios.FirstOrDefault(x => x.IdIdentity.ToString() == user.Id);

                    usersViewM.Add(new UsuarioViewModel()
                    {
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Nome = usuarioDto?.Nome,
                        Idade = usuarioDto?.Idade.ToString(),
                        Sobrenome = usuarioDto?.Sobrenome,
                        Endereco = usuarioDto?.Endereco,
                        Genero = usuarioDto?.Genero.ToString(),
                    });
                }


                if (usersViewM.Any())
                {
                    ViewBag.Message = $"Foram encontrados {usersViewM.Count()} resultados para a pesquisa '{searchString}'";
                }
                else
                {
                    ViewBag.Message = $"Não foram encontrados resultados para a pesquisa '{searchString}'";
                }

                return View(usersViewM);
            }

            
        }
    }



}
