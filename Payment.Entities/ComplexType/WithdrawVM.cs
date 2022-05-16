using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Entities.ComplexType
{
    public class WithdrawVM
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
