using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WSBFrontEnd.Models;

namespace WSBFrontEnd.Services
{

    public class ExchangeRateService : IExchangeRateService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRateService(HttpClient http)
        {
            _httpClient = http;
        }

        

        public async Task<ExchangeRate> GetExchange()
        {
            ExchangeRate list = new ExchangeRate();

           // _httpClient.BaseAddress = new Uri("");

            var response = await _httpClient.GetAsync("?base=ZAR");

            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<ExchangeRate>();
            }
            return list;
        }

        public float GetCurrencyRateInZarRand(string currency)
        {
            if (currency.ToLower() == "")
                throw new ArgumentException("Invalid Argument! currency parameter cannot be empty!");
            if (currency.ToLower() == "zar")
                throw new ArgumentException("Invalid Argument! Cannot get exchange rate from ZAR to ZAR");

            try
            {
                // Get currency exchange rate with ZAR from XMLNODE
                float exchangeRate = float.Parse(currency);
                return exchangeRate;
            }
            catch
            {
                // currency not parsed!! 
                // return default value
                return 0;
            }
        }

        public float GetExchangeRateRand(string from, string to, float amount = 1)
        {
            // If currency's are empty abort
            if (from == null || to == null)
                return 0;

            // Convert ZAR to ZAR
            if (from.ToLower() == "zar" && to.ToLower() == "zar")
                return amount;

            try
            {
                // First Get the exchange rate of both currencies in zar
                float toRate = GetCurrencyRateInZarRand(to);
                float fromRate = GetCurrencyRateInZarRand(from);

                // Convert Between Zar to Other Currency
                if (from.ToLower() == "zar")
                {
                    return (amount * toRate);
                }
                else if (to.ToLower() == "zar")
                {
                    return (amount / fromRate);
                }
                else
                {
                    // Calculate non ZAR exchange rates From A to B
                    return (amount * toRate) / fromRate;
                }
            }
            catch { return 0; }
        }
    
    }
}
