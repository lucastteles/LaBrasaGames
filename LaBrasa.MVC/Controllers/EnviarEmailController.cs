using LaBrasa.Infra.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LaBrasa.MVC.Controllers
{
    
    public class EnviarEmailController : Controller 
    {
        private readonly UserManager<ApplicationUser> userManager;

        public EnviarEmailController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SendEmail(string destinatario, string assunto, string corpo, IFormFile anexo)
        //{
        //    var apiKey = "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";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("lucasteles898@gmail.com", "Lucas Teles");
        //    var to = new EmailAddress(destinatario);
        //    var subject = assunto;
        //    var plainTextContent = corpo;
        //    var htmlContent = corpo;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        //    if (anexo != null && anexo.Length > 0)
        //    {
        //        byte[] arquivo = null;
        //        using (var stream = anexo.OpenReadStream())
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                await stream.CopyToAsync(memoryStream);
        //                arquivo = memoryStream.ToArray();
        //            }
        //        }

        //        var nomeArquivo = Path.GetFileName(anexo.FileName);
        //        var tipoArquivo = anexo.ContentType;
        //        var attachment = new Attachment()
        //        {
        //            Content = Convert.ToBase64String(arquivo),
        //            Filename = nomeArquivo,
        //            Type = tipoArquivo,
        //            Disposition = "attachment"
        //        };

        //        msg.AddAttachment(attachment);
        //    }

        //    var response = await client.SendEmailAsync(msg);

        //    ViewBag.Message = "Email enviado com sucesso!";
        //    return View();
        //}

        public async Task<IActionResult> SendEmail(string assunto, string corpo, IFormFile anexo)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("lucasteles898@gmail.com", "Lucas Teles");
            var subject = assunto;
            var plainTextContent = corpo;
            var htmlContent = corpo;

            // Recupera a lista de usuários do Identity
            var users = await userManager.Users.ToListAsync();

            // Itera sobre a lista de usuários, enviando um email para cada um
            foreach (var user in users)
            {
                var to = new EmailAddress(user.Email);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                if (anexo != null && anexo.Length > 0)
                {
                    byte[] arquivo = null;
                    using (var stream = anexo.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memoryStream);
                            arquivo = memoryStream.ToArray();
                        }
                    }

                    var nomeArquivo = Path.GetFileName(anexo.FileName);
                    var tipoArquivo = anexo.ContentType;
                    var attachment = new Attachment()
                    {
                        Content = Convert.ToBase64String(arquivo),
                        Filename = nomeArquivo,
                        Type = tipoArquivo,
                        Disposition = "attachment"
                    };

                    msg.AddAttachment(attachment);
                }

                var response = await client.SendEmailAsync(msg);
            }

            ViewBag.Message = "Email enviado com sucesso!";
            return View();
        }

    }

}
