using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.BLL.Abstract;
using Payment.Entities.ComplexType;
using Payment.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionHistoryService _transactionHistoryService;
        public HomeController(IAccountService accountService, ITransactionHistoryService transactionHistoryService)
        {
            _accountService = accountService;
            _transactionHistoryService = transactionHistoryService;
        }

        [Route("/account")]
        [HttpPost]
        public IActionResult CreateAccount([FromForm]CreateAccountVM account)
        {
            var response = _accountService.CreateAccount(account);
            return StatusCode(response.StatusCode, response.ResponseMessage);
        }
        [Route("/account/{accountNumber}")]
        [HttpGet]
        public IActionResult GetAccount(int accountNumber)
        {
            var response = _accountService.GetAccount(accountNumber);
            return StatusCode(response.StatusCode, response.ResponseMessage);
        }
        [Route("/accounting/{accountNumber}")]
        [HttpGet]
        public IActionResult GetTransactionHistories(int accountNumber)
        {
            var response = _transactionHistoryService.GetAccountTransactionHistories(accountNumber);
            return StatusCode(response.StatusCode, response.ResponseMessage);
        }
        [Route("/payment")]
        [HttpPost]
        public IActionResult Payment([FromBody]PaymentVM paymentVM)
        {
            var response = _accountService.CreatePayment(paymentVM);
            return StatusCode(response.StatusCode, response.ResponseMessage);
        }
        [Route("/deposit")]
        [HttpPost]
        public IActionResult Deposit([FromBody]DepositVM depositVM)
        {
            var response = _accountService.CreateDeposit(depositVM);
            return StatusCode(response.StatusCode, response.ResponseMessage);
        }
        [Route("/withdraw")]
        [HttpPost]
        public IActionResult Withdraw([FromBody]WithdrawVM withdrawVM)
        {
            var response = _accountService.CreateWithdraw(withdrawVM);
            return StatusCode(response.StatusCode, response.ResponseMessage);
        }

    }
}
