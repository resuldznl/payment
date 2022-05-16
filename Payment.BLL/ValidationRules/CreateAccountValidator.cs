using FluentValidation;
using Payment.Entities.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BLL.ValidationRules
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountVM>
    {
        public CreateAccountValidator()
        {
            RuleFor(p => p.OwnerName).NotEmpty().NotNull().WithMessage("Owner Name is Required");
            RuleFor(p => p.OwnerName).MinimumLength(5).MaximumLength(20).WithMessage("Owner Name must be between 5 and 20 characters!");
            RuleFor(p => p.AccountNumber).NotEmpty().NotNull().WithMessage("Account Number is Required");
            RuleFor(p => p.AccountType.ToString()).NotEmpty().NotNull().WithMessage("Account Type is Required");
            RuleFor(p => p.CurrencyCode.ToString()).NotEmpty().NotNull().WithMessage("Currency Code is Required");
        }
    }
}
