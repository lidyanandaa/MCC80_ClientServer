using API.Contracts;
using API.DTOs.Accounts;
using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validation.Accounts
{
    public class NewAccountValidator : AbstractValidator<NewAccountDto>
    {
        private readonly IAccountRepository _accountRepositoryu;
        public NewAccountValidator(IAccountRepository accountRepository)
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
