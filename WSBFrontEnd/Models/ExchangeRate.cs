using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace WSBFrontEnd.Models
{
    // json objects

    public partial class ExchangeRate
    {
        [JsonProperty("motd")]
        public motdObj Motd { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rates")]
        public Rate Rates { get; set; }       
    }

    public partial class motdObj
    {
        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }

    public partial class Rate
    {
        //USD, EUR,  GBP, HKD & KES
        public string USD { get; set; }
        public string EUR { get; set; }
        public string GBP { get; set; }
        public string HKD { get; set; }
        public string KES { get; set; }
       
    }

    public class Values
    {
        //[DataType(DataType.Currency)]
       // [Display(Name = "Please Enter Rand value")]
        [Required]
        public double rand { get; set; }
        public string zar { get; set; }
        public double equivelant { get; set; }


        public float amount { get; set; }
        public string from { get; set; }
        public string to { get; set; }

    }




}