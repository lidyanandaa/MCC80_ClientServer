using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validation.Accounts
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public LoginValidator(IEmployeeRepository employeeRepository)
        {
            RuleFor(login => login.Email)
               .NotEmpty()
               .EmailAddress();

            RuleFor(login => login.Password)
                .NotEmpty();
        }
    }
}
