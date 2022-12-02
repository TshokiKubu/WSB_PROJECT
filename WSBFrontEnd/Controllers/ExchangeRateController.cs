using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSBFrontEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;

namespace WSBFrontEnd.Controllers
{
    public class ExchangeRateController : Controller
    {

        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {
            List<ExchangeRate> list = new List<ExchangeRate>();

            //  DataTable dt = new DataTable();
            client.BaseAddress = new Uri("https://api.exchangerate.host/latest");
            //"http://localhost:34940/api/ExchangeRate");//http://localhost:34940/api/ExchangeRate
            var response = await client.GetAsync("?base=ZAR");
          //  response.Wait();

           // var test = response.Result;

            if(response.IsSuccessStatusCode)
            {
                var display = response.Content.ReadAsAsync<List<ExchangeRate>>();
               // display.Wait();
               // list = display.Result;
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Server error, try after some time.");
            }           

            return View(list);
        }
    }
}
