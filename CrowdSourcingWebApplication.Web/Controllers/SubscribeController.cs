using CrowdSourcingWebApplication.Web.Handlers;
using CrowdSourcingWebApplication.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CrowdSourcingWebApplication.Web.Controllers
{
    public class SubscribeController : Controller
    {
        HttpClient client;


        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult aaaaa(User user)
        {


            client = new HttpClient();
            client.BaseAddress = new Uri("https://crowdsourcinggraphapi.azurewebsites.net/api/Users");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
            HttpContent content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());
            var requestMessage = new HttpRequestMessage();
            var response = client.PostAsync(client.BaseAddress, content);

            var code = response.Result.StatusCode;

             
          /*  HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44311/api/Users");
            HttpResponseMessage response = await client.SendAsync(request);
           * 
           * */

            return RedirectToAction("Index", "Home");
        }
    }
}