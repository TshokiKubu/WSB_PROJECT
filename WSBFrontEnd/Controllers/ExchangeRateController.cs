using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSBFrontEnd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;


namespace WSBFrontEnd.Controllers
{
    public class ExchangeRateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
