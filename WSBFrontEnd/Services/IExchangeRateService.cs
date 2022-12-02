using System.Collections.Generic;
using System.Threading.Tasks;
using WSBFrontEnd.Models;

namespace WSBFrontEnd.Services
{
    public interface IExchangeRateService
    {
        Task<ExchangeRate> GetExchange();


        float GetCurrencyRateInZarRand(string currency);
        float GetExchangeRateRand(string from, string to, float amount = 1);
    }
}