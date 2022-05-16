using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Entities.ComplexType
{
    public class PaymentVM
    {
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public decimal Amount { get; set; }
    }
}
