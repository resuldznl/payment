using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Payment.Entities.Models
{
    public class TransactionHistory
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public enum TransactionTypes { payment, deposit, withdraw};

}
