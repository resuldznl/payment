using Payment.Entities.ComplexType;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL.Abstract
{
    public interface ITransactionHistoryService
    {
        ResponseModel GetAccountTransactionHistories(int accountNumber);
        void CreateTransactionHistory(TransactionHistory transactionHistory);

    }
}
