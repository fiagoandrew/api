using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using apiApp.Models;
using static apiApp.Models.Backbone;

namespace apiApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string submit)
        {
            // If a result was passed
            if (submit == "value1")
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // create the response
                HttpResponseMessage response = client.GetAsync("https://swapi.co/api/starships/10").Result;
                GetAccountResponse yourcustomobjects = response.Content.ReadAsAsync<GetAccountResponse>().Result;
               
                // store the response
                ViewBag.Message = "Please head to your Starship: " + yourcustomobjects.name.ToString();
            }

            // call the page
            return View();
        }        
    }
}