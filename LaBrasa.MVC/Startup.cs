using LaBrasa.Domain.Account;
using LaBrasa.Infra.Data.Identity;
using LaBrasa.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaBrasa.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            //services.AddControllersWithViews();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin",
            //        politica =>
            //        {
            //            politica.RequireRole("Admin");
            //        });
            //});

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//vai valer por todo o tempo de vida da Aplicação (as informações vão permanecer)

            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                       .RequireAuthenticatedUser()
                       .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }); 

           
           

            
           
            services.AddMemoryCache(); //Registrando os middes (Onde São Armazenados os Dados)
            services.AddSession(options => //Recurso para Salvar e Armazenar dados do Usuário
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();


            //cria os perfis
            seedUserRoleInitial.SeedRoles();
            //cria os usuários e atribui ao pefil
            seedUserRoleInitial.SeedUsers(); //SeedUsersRoles


            app.UseSession();
            app.UseAuthentication();//Sempre Antes da Autorização 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=AdminAccount}/{action=Usuario}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");


            });
        }
    }
}
