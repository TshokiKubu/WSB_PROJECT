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

        [HttpGet]
        public async Task<ExchangeRate> GetRatesAsync()
        {
            // return  getAll();
            ExchangeRate ex = null;

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.exchangerate.host");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var er = await client.GetAsync("/latest?base=ZAR");

                // Declare this object before if


                if (er.IsSuccessStatusCode)
                {
                    string a = await er.Content.ReadAsStringAsync();
                    ex = JsonConvert.DeserializeObject<ExchangeRate>(a);
                }               
            }
            catch (Exception e)
            {

            }
            return ex;

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
