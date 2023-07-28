using API.Contracts;
using API.DTOs.Roles;
using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validation.Roles
{
    public class NewRoleValidator : AbstractValidator<NewRoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        public NewRoleValidator(IRoleRepository roleRepository)
        {
            RuleFor(rl => rl.Name)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Name more than maximum length");
        }
    }
}
