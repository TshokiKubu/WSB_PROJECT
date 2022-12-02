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
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WSBFrontEnd.Services;

namespace WSBFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExchangeRateService _exService;


        public HomeController(ILogger<HomeController> logger, IExchangeRateService exService)
        {
            _logger = logger;
            _exService = exService;
        }

       

        public async Task<IActionResult> Index()
        {           
            return View();
        } 
        
        public async Task<JsonResult> GetExchangeRate()
        {
            var exchange = await _exService.GetExchange();
            var list = new List<Conversion>()
            {
                new Conversion(){
                    name = "USD",
                    value = exchange.Rates.USD
                },
                new Conversion(){
                    name = "EUR",
                    value = exchange.Rates.EUR
                },
                new Conversion(){
                    name = "GBP",
                    value = exchange.Rates.GBP
                },
                new Conversion(){
                    name = "HKD",
                    value = exchange.Rates.HKD
                },
                new Conversion(){
                    name = "KES",
                    value = exchange.Rates.KES
                },
            };           

            return Json(list?.ToArray());

        }

        [HttpPost]
        public ActionResult CurrencyConverter(string from , string to, float amount = 1 )
        {
            //from = "ZAR";
            //to = "USD";
            //amount = 500;
            var convertedValue = 0.0;

            ExchangeRate exR = new ExchangeRate();
            Values vl = new Values();
            Conversion cnv = new Conversion();

            vl.from = "ZAR";
            vl.to = cnv.name;
            vl.amount = amount;

            //C# code here
            var convert =  _exService.GetExchangeRateRand(from, to, amount);

            convertedValue = (amount * cnv.rand);

            ViewBag.Result = convertedValue;// amount;

            return View(convert);// (convert);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
