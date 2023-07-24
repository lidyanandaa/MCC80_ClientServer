using API.Contracts;
using API.DTOs.Educations;
using API.DTOs.Roles;
using FluentValidation;

namespace API.Utilities.Validation.Educations
{
    public class NewEducationValidator : AbstractValidator<NewEducationDto>
    {
        private readonly IEducationRepository _educationRepository;
        public NewEducationValidator(IEducationRepository educationRepository)
        {
            RuleFor(ed => ed.Major)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Major more than maximum length");
            RuleFor(ed => ed.Degree)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Degree more than maximum length");
            RuleFor(ed => ed.Gpa)
                .NotEmpty();
            RuleFor(ed => ed.UniversityGuid)
                .NotEmpty();
        }
    }
}
