using Payment.Entities.ComplexType;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL.Abstract
{
    public interface IAccountService
    {
        ResponseModel CreateAccount(CreateAccountVM account);
        ResponseModel GetAccount(int accountNumber);
        ResponseModel CreatePayment(PaymentVM paymentVM);
        ResponseModel CreateDeposit(DepositVM depositVM);
        ResponseModel CreateWithdraw(WithdrawVM withdrawVM);
    }
}
