using Labrasa.Application.Interfaces;
using Labrasa.Application.Mappings;
using Labrasa.Application.Services;
using LaBrasa.Domain.Account;
using LaBrasa.Domain.Interfaces;
using LaBrasa.Infra.Data.Context;
using LaBrasa.Infra.Data.Identity;
using LaBrasa.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBrasa.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false; //Obriga a ter um numero na senha
                                                       //options.Password.RequiredLength = 7; // valor default 8 digitos
                options.Password.RequiredUniqueChars = 6; // minimos caracteres unicos
                options.Password.RequireLowercase = false; // não é obrigatório começar com minusculo
                options.Password.RequireNonAlphanumeric = false; // não é obrigatório alfanumerico
                options.Password.RequireUppercase = false; // não é obrigatorio começar com maiusculo
            });

            return services;
        }
    }
}
