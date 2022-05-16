using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Payment.Entities.Models
{

    public class Account
    {
        public int AccountNumber { get; set; } 
        public string OwnerName { get; set; }
        public CurrencyCodes CurrencyCode { get; set; }
        public AccountTypes AccountType { get; set; }
        public decimal Balance { get; set; }
    }
    public enum CurrencyCodes { TRY, USD, EUR };
    public enum AccountTypes { individual, corporate };
}
