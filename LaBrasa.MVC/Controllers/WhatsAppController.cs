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
    }



    //    using Microsoft.AspNetCore.Mvc;
    //using RestSharp;
    //using System.Threading.Tasks;

    //namespace YourApplication.Controllers
    //    {
    //        public class WhatsAppController : Controller
    //        {
    //            private readonly string _instanceId;
    //            private readonly string _token;
    //            private readonly RestClient _client;

    //            public WhatsAppController()
    //            {
    //                _instanceId = "instance950"; // your instanceId
    //                _token = "yourtoken";         //instance Token
    //                _client = new RestClient($"https://api.ultramsg.com/{_instanceId}/messages/chat");
    //            }

    //            public async Task<IActionResult> SendMessage(string mobile, string message)
    //            {
    //                var request = new RestRequest(Method.POST);
    //                request.AddHeader("content-type", "application/x-www-form-urlencoded");
    //                request.AddParameter("token", _token);
    //                request.AddParameter("to", mobile);
    //                request.AddParameter("body", message);

    //                var response = await _client.ExecuteAsync(request);

    //                if (response.IsSuccessful)
    //                {
    //                    return Ok(response.Content);
    //                }
    //                else
    //                {
    //                    return BadRequest(response.ErrorMessage);
    //                }
    //            }
    //        }
    //    }

    //    //startup
    //    app.UseEndpoints(endpoints =>
    //{
    //    endpoints.MapControllerRoute(
    //        name: "whatsapp",
    //        pattern: "whatsapp/sendmessage/{mobile}/{message}",
    //        defaults: new { controller = "WhatsApp", action = "SendMessage" });
    //});


}





//public class WhatsAppController : Controller
//{
//    private readonly RestClient _client;

//    public WhatsAppController()
//    {
//        _client = new RestClient("https://api.ultramsg.com/");
//    }

//    [HttpGet]
//    public IActionResult SendMessage()
//    {
//        return View();
//    }

//    [HttpPost]
//    public async Task<IActionResult> SendMessage(string mobile, string message)
//    {
//        var request = new RestRequest($"instance41697/messages/chat", Method.POST);
//        request.AddHeader("content-type", "application/x-www-form-urlencoded");
//        request.AddParameter("token", "to9ohy3r0e3xnb1k");
//        request.AddParameter("to", mobile);
//        request.AddParameter("body", message);

//        var response = await _client.ExecuteAsync(request);

//        if (response.IsSuccessful)
//        {
//            TempData["Response"] = response.Content;
//            return RedirectToAction(nameof(Success));
//        }
//        else
//        {
//            ViewBag.Error = response.ErrorMessage;
//            return View();
//        }
//    }

//    [HttpGet]
//    public IActionResult Success()
//    {
//        ViewBag.Response = TempData["Response"];
//        return View();
//    }
//}


//@{
//    ViewData["Title"] = "Send Message";
//}

//< h1 > Send Message </ h1 >

//   @if(ViewBag.Error != null)
//{
//    < div class= "alert alert-danger" >
//         @ViewBag.Error
//     </ div >
//}

//< form method = "post" >
 
//     < div class= "form-group" >
  
//          < label for= "mobile" > Mobile Number:</ label >
   
//           < input type = "text" class= "form-control" id = "mobile" name = "mobile" placeholder = "Enter mobile number" required >
             
//                 </ div >
             
//                 < div class= "form-group" >
              
//                      < label for= "message" > Message:</ label >
               
//                       < textarea class= "form-control" id = "message" name = "message" rows = "3" required ></ textarea >
                       
//                           </ div >
                       
//                           < button type = "submit" class= "btn btn-primary" > Send </ button >
//                          </ form >