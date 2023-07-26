using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validation.Accounts
{
    public class AccountValidator : AbstractValidator<AccountDto>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountValidator(IAccountRepository accountRepository)
        {
            RuleFor(a => a.Password)
                .NotEmpty()
                //membuat karakter password mengandung angka, karakter, huruf besar dan hurus kecil, menggunakan regex
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
