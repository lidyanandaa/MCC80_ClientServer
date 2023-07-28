using API.Contracts;
using API.DTOs.AccountRoles;
using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validation.AccountRoles
{
    public class NewAccountRoleValidator : AbstractValidator<NewAccountRoleDto>
    {
        private readonly IAccountRoleRepository _accountRoleRepository;

        public NewAccountRoleValidator(IAccountRoleRepository accountRoleRepository)
        {
            RuleFor(ac => ac.AccountGuid)
                .NotEmpty();
            RuleFor(ac => ac.RoleGuid)
                .NotEmpty();
        }
    }
}
