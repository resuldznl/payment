using Newtonsoft.Json.Converters;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Payment.Entities.ComplexType
{
    public class CreateAccountVM
    {
        public int AccountNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCodes CurrencyCode { get; set; }
        public string OwnerName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypes AccountType { get; set; }
    }

}
