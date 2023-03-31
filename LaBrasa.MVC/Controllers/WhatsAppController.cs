using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Threading.Tasks;

namespace LaBrasa.MVC.Controllers
{
    public class WhatsAppController : Controller
    {
        private readonly string instanceId = "instance41697";
        private readonly string token = "to9ohy3r0e3xnb1k";


        //public async Task<IActionResult> GetApiResponseAsync()
        //{
        //    var url = "https://api.ultramsg.com/instance41697/instance/status";
        //    var client = new RestClient(url);
        //    var request = new RestRequest(url, Method.Get);
        //    request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //    request.AddParameter("token", "to9ohy3r0e3xnb1k");

        //    RestResponse response = await client.ExecuteAsync(request);
        //    var output = response.Content;

        //    return View(output);
        //}


        //public async Task<IActionResult> GetApi()
        //{
        //    WhatsAppController controller = new WhatsAppController();
        //    IActionResult result = await controller.GetApiResponseAsync(); 

        //    return result;
        //}


        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string mobile, string message)
        {
            var url = $"https://api.ultramsg.com/instance41697/messages/chat";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", token);
            request.AddParameter("to", mobile);
            request.AddParameter("body", message);



            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            ViewBag.Response = output;
            return View();
        }


        [HttpGet]
        public IActionResult SendImage()
        {
            return View();
        }
         
        [HttpPost]
        public async Task<IActionResult> SendImage(string mobile,  string imageUrl, string captiontxt)
        {
            var url = $"https://api.ultramsg.com/instance41697/messages/image";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", token);
            request.AddParameter("to", mobile);
            request.AddParameter("image", imageUrl);
            request.AddParameter("caption", captiontxt);


            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            ViewBag.Response = output;
            return View();
        }

        [HttpGet]
        public IActionResult SendVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendVideo(string mobile, string videoUrl, string captiontxt)
        {
            var url = $"https://api.ultramsg.com/instance41697/messages/video";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", token);
            request.AddParameter("to", mobile);
            request.AddParameter("video", videoUrl);
            request.AddParameter("caption", captiontxt);
             

            RestResponse response = await client.ExecuteAsync(request);
            var output = response.Content;
            ViewBag.Response = output;
            return View();
        }
    }

}