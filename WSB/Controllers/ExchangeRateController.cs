using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using WSB.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WSB.Repositories;

namespace WSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        //public ExchangeRateController()
        //{
        //    GetRatesAsync();
        //}
        private readonly IExchangeRepository _exRepo;
        
        public ExchangeRateController(IExchangeRepository exRepo)
        {
            _exRepo = exRepo;            
        }

        [HttpGet]
        public async Task<ExchangeRate> GetRatesAsync(string from, string to, float amount = 1)
        {
            // return  getAll();
           // var content = 0.0;// = null;
             ExchangeRate ex = null;
          //  var content = ex;
           // var content = (float?)null;
           //  IEnumerable<ExchangeRate> content = null;
           //   string[] content = null;
           //    public float content;

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.exchangerate.host");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var er = await client.GetAsync("/latest?base=ZAR");
                
                var objListCurrencies = _exRepo.GetExchangeRateRand(from, to,amount);

                // Declare this object before if
                if (er.IsSuccessStatusCode)
                {
                    string a = await er.Content.ReadAsStringAsync();
                    ex = JsonConvert.DeserializeObject<ExchangeRate>(a);

                   var content =  ex.Rates;

                    ///  var obj = JObject.Parse(a);
                    //    var currencyValue = (string)obj.SelectToken("Rows.Row[0].motd.rate[1].value");

                    //    var currencyValue = (string)obj.SelectToken("motd").SelectToken("msg").SelectToken("url")
                    //     .SelectToken("success").SelectToken("base").SelectToken("date").SelectToken("rate").Value<string>();

                }               
            }
            catch (Exception e)
            {

            }
            return ex;// content;//  ex;

        }


        [HttpPost]
        public  double convert(double rands, string currency)
        {
            // var res = GetExchangeRate(currency);
            //   double c = getCurreny(currency);
            //     double convertedAmount = rands * c;
            //     return convertedAmount;

            // Convert string to number
            
            return rands;
        }


     //   public double getCurreny(double b)
      //  {
            //  var a = await nmgetAll().Results.Where(s => s.Rate == "b");

            //  return a.value();

     //       return b;
     //   }


      
    }
    
}
