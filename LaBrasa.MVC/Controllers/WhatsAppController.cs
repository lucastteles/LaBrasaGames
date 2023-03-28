using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Threading.Tasks;

namespace LaBrasa.MVC.Controllers
{
    public class WhatsAppController : Controller
    {
        private readonly string instanceId = "instance41697";
        private readonly string token = "to9ohy3r0e3xnb1k";

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string mobile, string message, string imageUrl, string captiontxt)
        {
            var url = $"https://api.ultramsg.com/instance41697/messages/chat";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", token);
            request.AddParameter("to", mobile);
            request.AddParameter("body", message);
            request.AddParameter("image", imageUrl);
            request.AddParameter("caption", captiontxt);

            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            ViewBag.Response = output;
            return View();
        }
    }

}