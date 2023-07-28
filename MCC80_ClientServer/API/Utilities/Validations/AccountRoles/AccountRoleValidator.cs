using API.Contracts;
using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validation.AccountRoles
{
    public class AccountRoleValidator : AbstractValidator<AccountRoleDto>
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRoleValidator(IAccountRoleRepository accountRoleRepository)
        {
            RuleFor(ac => ac.AccountGuid)
                .NotEmpty();
            RuleFor(ac => ac.RoleGuid)
                .NotEmpty();
        }
    }
}
