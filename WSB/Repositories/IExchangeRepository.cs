using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSB.Models;

namespace WSB.Repositories
{
    public interface IExchangeRepository
    {
       //string  getCurrency(string b);
       //  public double <ExchangeRate> getCurreny(double b);
       ICollection<ExchangeRate> GetExchangeRateCurrency(string currency);
       float GetCurrencyRateInZarRand(string currency);
       float GetExchangeRateRand(string from, string to, float amount = 1);
    }
}
