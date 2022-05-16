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
    public class GetAccountVM
    {
        public int AccountNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string OwnerName { get; set; }
        public AccountTypes AccountType{ get; set; }
        public double Balance { get; set; }
    }
}
