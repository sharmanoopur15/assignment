﻿using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace ReferalRockAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JObject GetResponse(string method)
        {
            var responsestring = string.Empty;
            var jo = new JObject();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.referralrock.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "sharma.noopur15@gmail.com", "Password$1"))));
                var response = client.GetAsync(method).Result;
                if (response.IsSuccessStatusCode)
                {
                    responsestring = response.Content.ReadAsStringAsync().Result;
                    jo = JObject.Parse(responsestring);
                }
            }

            return jo;



        }
    }
}
    
