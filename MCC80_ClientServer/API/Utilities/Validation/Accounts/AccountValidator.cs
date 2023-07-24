using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validation.Accounts
{
    public class AccountValidator : AbstractValidator<AccountDto>
    {
        private readonly IAccountRepository _accountRepositoryu;
        public AccountValidator(IAccountRepository accountRepository)
        {
            RuleFor(a => a.Password)
                .NotEmpty()
                .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Password not valid");
            RuleFor(a => a.Otp)
                .NotEmpty();
            RuleFor(a => a.IsUsed)
                .NotEmpty();
            RuleFor(a => a.ExpiredTime)
                .NotEmpty();
        }
    }
}
