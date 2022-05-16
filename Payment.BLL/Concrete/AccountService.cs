using AutoMapper;
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
    public class AccountService : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly ITransactionHistoryService _transactionHistoryService;
        private readonly IMapper _mapper;
        public AccountService(IAccountDal accountDal, ITransactionHistoryService transactionHistoryService, IMapper mapper)
        {
            _accountDal = accountDal;
            _transactionHistoryService = transactionHistoryService;
            _mapper = mapper;
        }

        public ResponseModel CreateAccount(CreateAccountVM account)
        {

            if (_accountDal.Get(p => p.AccountNumber == account.AccountNumber) == null)
                return _accountDal.Add(_mapper.Map<Account>(account)) ? new() { StatusCode = 200, ResponseMessage = "Account Creation Successful" } : new() { StatusCode = 500, ResponseMessage = "Account Creation Failed" };
            else
                return new() { StatusCode = 400, ResponseMessage = "There is a record of the entered Account Number." };
        }
        public ResponseModel GetAccount(int accountNumber)
        {
            var account = _accountDal.Get(p => p.AccountNumber == accountNumber);
            return account != null ? new() { StatusCode = 200, ResponseMessage = _mapper.Map<GetAccountVM>(account) } : new() { StatusCode = 404, ResponseMessage = "Account Not Found" };
        }
        public ResponseModel CreatePayment(PaymentVM paymentVM)
        {
            var senderControl = _accountDal.Get(p => p.AccountNumber == paymentVM.SenderAccount && p.AccountType == AccountTypes.individual);
            var receiverControl = _accountDal.Get(p => p.AccountNumber == paymentVM.ReceiverAccount && p.AccountType == AccountTypes.corporate);
            if(senderControl != null && receiverControl != null)
            {
                if(senderControl.Balance >= paymentVM.Amount)
                {
                    senderControl.Balance = Convert.ToDecimal(String.Format("{0:0.00}", senderControl.Balance - paymentVM.Amount));
                    _accountDal.Update(senderControl);
                    _transactionHistoryService.CreateTransactionHistory(new() { AccountNumber = senderControl.AccountNumber, Amount = paymentVM.Amount, TransactionType = TransactionTypes.payment });
                    return new() { StatusCode = 200, ResponseMessage = "Payment Transaction Successful" };
                }
                else
                    return new() { StatusCode = 400, ResponseMessage = "Insufficient Account Balance" };
            }
            return new() { StatusCode = 400, ResponseMessage = "Invalid Sender or Receiver Account" };
        }
        public ResponseModel CreateDeposit(DepositVM depositVM)
        {
            var accountControl = _accountDal.Get(p => p.AccountNumber == depositVM.AccountNumber && p.AccountType == AccountTypes.individual);
            if(accountControl != null)
            {
                accountControl.Balance = Convert.ToDecimal(String.Format("{0:0.00}", accountControl.Balance + depositVM.Amount));
                _accountDal.Update(accountControl);
                _transactionHistoryService.CreateTransactionHistory(new() { AccountNumber = accountControl.AccountNumber, Amount = depositVM.Amount, TransactionType = TransactionTypes.deposit });
                return new() { StatusCode = 200, ResponseMessage = "Deposit Transaction Successful" };
            }
            return new() { StatusCode = 400, ResponseMessage = "Invalid Account" };
        }
        public ResponseModel CreateWithdraw(WithdrawVM withdrawVM)
        {
            var accountControl = _accountDal.Get(p => p.AccountNumber == withdrawVM.AccountNumber && p.AccountType == AccountTypes.individual);
            if(accountControl != null)
            {
                if(accountControl.Balance >= withdrawVM.Amount)
                {
                    _accountDal.Update(accountControl);
                    _transactionHistoryService.CreateTransactionHistory(new() { AccountNumber = accountControl.AccountNumber, Amount = withdrawVM.Amount, TransactionType = TransactionTypes.withdraw });
                    return new() { StatusCode = 200, ResponseMessage = "Withdraw Transaction Successful" };
                }
                else
                    return new() { StatusCode = 400, ResponseMessage = "Insufficient Account Balance" };
            }
            return new() { StatusCode = 400, ResponseMessage = "Invalid Account" };
        }
    }
}
