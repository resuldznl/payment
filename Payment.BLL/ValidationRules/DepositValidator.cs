using FluentValidation;
using Payment.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL.ValidationRules
{
    public class DepositValidator : AbstractValidator<DepositVM>
    {
        public DepositValidator()
        {
            RuleFor(p => p.AccountNumber).NotEmpty().NotNull().WithMessage("Account Number is Required");
            RuleFor(p => p.Amount).NotEmpty().NotNull().WithMessage("Amount is Required");
            RuleFor(p => p.Amount).Must(p => p > 10.00m || p < 10000.00m).WithMessage("Minimum 10 Maximum 10000 units can be entered");
        }
    }
}
