﻿using Labrasa.Application.DTOs;
using Labrasa.Application.Interfaces;
using LaBrasa.Domain.Account;
using LaBrasa.Infra.Data.Identity;
using LaBrasa.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaBrasa.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUsuarioService _usuarioService;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAuthenticate authenticate,
            IUsuarioService usuarioService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _authenticate = authenticate;
            _usuarioService = usuarioService;

            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Email);

                TempData["cliente"] = user.Id.ToString();

                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(applicationUser, model.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");
                return View(model);
            }

            await _signInManager.SignInAsync(applicationUser, isPersistent: false);

            var usuarioDto = new UsuarioDTO()
            {
                IdIdentity = Guid.Parse(applicationUser.Id),
                Endereco = model.Endereco,
                Nome = model.Nome,
                Sobrenome = model.Sobrenome,
                Genero = model.Genero,
                Idade = model.Idade,
            };

            await _usuarioService.Adicionar(usuarioDto);

            return Redirect("/");

        }

        [HttpGet]
        public async Task<IActionResult> Perfil()  //, LoginViewModel model)
        {
            var idUsuario = TempData["cliente"].ToString();

            var usuario = await _usuarioService.ObterPorId(Guid.Parse(idUsuario));
            //var usersIdentity = _userManager.Users.;






            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }

    }
}

