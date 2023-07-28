﻿using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class RegisterValidator : AbstractValidator<RegisterDto> //buat class RegisterValidator yang mewarisi AbstractValidator dari entity RegisterDto
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;
        public RegisterValidator(IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _employeeRepository = employeeRepository;
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;

            // rule for employee
            RuleFor(e => e.FirstName)
                .NotEmpty();

            RuleFor(e => e.LastName)
                .NotEmpty();

            RuleFor(e => e.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.AddYears(-10));

            RuleFor(e => e.Gender)
                .NotNull().IsInEnum();

            RuleFor(e => e.HiringDate)
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                .Must(IsDuplicateValue).WithMessage("Email already exists");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20)
                .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Password not valid")
                .Must(IsDuplicateValue).WithMessage("Phone Number already exists");

            // rule for university
            RuleFor(u => u.UniversityName)
                .NotEmpty().WithMessage("University name is required");

            RuleFor(u => u.UniversityCode)
                .NotEmpty().WithMessage("University code is required"); ;

            // rule for education 
            RuleFor(e => e.Major)
                .NotEmpty().WithMessage("Major is required"); ;

            RuleFor(e => e.Degree)
                .NotEmpty().WithMessage("Degree is required"); ;

            RuleFor(e => e.Gpa)
                .NotEmpty().WithMessage("GPA is required"); ;

            // rule for account
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(a => a.ConfirmPassword).NotEmpty().Equal(a => a.ConfirmPassword).WithMessage("Password don't match");

            //RuleFor(a => a.OTP).NotEmpty();
        }

        private bool IsDuplicateValue(string value)
        {
            return _employeeRepository.isNotExist(value);
        }
    }
}