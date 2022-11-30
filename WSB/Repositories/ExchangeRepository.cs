using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WSB.Models;

namespace WSB.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        public string getCurrency(string b)
        {
            //var a = await nmgetAll().Results.Where(s => s.Rate == "b");
            //  var a =  Results.Where(s => s.Rate == "b");
            //  return a.value();

            return b;// * 7.00;
        }

        /// <summary>
        /// Get currency exchange rate in euro's 
        /// </summary>
        public static float GetCurrencyRateInZar(string currency)
        {
            if (currency.ToLower() == "")
                throw new ArgumentException("Invalid Argument! currency parameter cannot be empty!");
            if (currency.ToLower() == "zar")
                throw new ArgumentException("Invalid Argument! Cannot get exchange rate from ZAR to ZAR");

            try
            {                
              // Get currency exchange rate with EURO from XMLNODE
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

        /// <summary>
        /// Get The Exchange Rate Between 2 Currencies
        /// </summary>
        public static float GetExchangeRate(string from, string to, float amount = 1)
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
                float toRate = GetCurrencyRateInZar(to);
                float fromRate = GetCurrencyRateInZar(from);

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

