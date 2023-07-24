using API.Contracts;
using API.DTOs.Accounts;
using API.DTOs.Roles;
using FluentValidation;

namespace API.Utilities.Validation.Roles
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        public RoleValidator(IRoleRepository roleRepository)
        {
            RuleFor(rl => rl.Name)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Name more than maximum length");
        }
    }
}
