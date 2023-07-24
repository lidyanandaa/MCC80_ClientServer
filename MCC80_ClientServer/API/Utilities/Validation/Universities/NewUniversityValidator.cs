
using API.Contracts;
using API.DTOs.Employees;
using API.DTOs.Universities;
using FluentValidation;

namespace API.Utilities.Validation.Universities
{
    public class NewUniversityValidator : AbstractValidator<NewUniversityDto>
    {
        private readonly IUniversityRepository _universityRepository;

        public NewUniversityValidator(IUniversityRepository universityRepository)
        {
            RuleFor(u => u.Code)
                .NotEmpty()
                .MaximumLength(50).WithMessage("Code more than maximum length");
            RuleFor(u => u.Name)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Name more than maximum length");
        }
    }
}
