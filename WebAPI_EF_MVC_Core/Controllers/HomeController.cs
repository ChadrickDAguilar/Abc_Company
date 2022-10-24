using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abc_Company.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Abc_Company.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public IActionResult Index()
        {
            List<CarrierModel> Carriers = SearchCarriers("");
            ViewBag.Carriers = Carriers;
            return View(Carriers);
        }
        //gets nearby carriers
        [HttpGet]
        public IActionResult Index(string name, string amount)
        {
            ViewBag.amount = amount;
            List<CarrierModel> Carriers = SearchCarriers("");
            return View(Carriers);
        }
        //Get search result from submit button
        [HttpPost]
        public IActionResult Index(string name)
        {
            List<CarrierModel> Carriers = SearchCarriers(name);
            return View(Carriers);
        }


        private static List<CarrierModel> SearchCarriers(string name)
        {
            List<CarrierModel> Carriers = new List<CarrierModel>();
            string apiUrl = "https://localhost:44318/api/CarrierAPI";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/GetCarriers?name={0}", name)).Result;
            if (response.IsSuccessStatusCode)
            {
                Carriers = JsonConvert.DeserializeObject<List<CarrierModel>>(response.Content.ReadAsStringAsync().Result);
            }

            return Carriers;
        }
    }
}