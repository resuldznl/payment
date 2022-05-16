using Payment.BLL.Abstract;
using Payment.DAL.Abstract;
using Payment.Entities.ComplexType;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL.Concrete
{
    public class TransactionHistoryService : ITransactionHistoryService
    {
        private readonly ITransactionHistoryDal _transactionHistoryDal;
        public TransactionHistoryService(ITransactionHistoryDal transactionHistoryDal)
        {
            _transactionHistoryDal = transactionHistoryDal;
        }
        public ResponseModel GetAccountTransactionHistories(int accountNumber)
        {
            var transactionHistories = _transactionHistoryDal.GetAll(p => p.AccountNumber == accountNumber);
            return transactionHistories.Count() >= 1 ? new() { StatusCode = 200, ResponseMessage = transactionHistories } : new() { StatusCode = 404, ResponseMessage = "No Transaction History Found For Account" };
        }
        public void CreateTransactionHistory(TransactionHistory transactionHistory)
            => _transactionHistoryDal.Add(transactionHistory);
    }
}
