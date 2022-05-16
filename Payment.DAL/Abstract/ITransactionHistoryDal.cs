using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Abstract
{
    public interface ITransactionHistoryDal : IRepository<TransactionHistory>
    {
    }
}
