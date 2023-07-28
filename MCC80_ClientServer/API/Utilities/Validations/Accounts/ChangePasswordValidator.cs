﻿using API.Contracts;
using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public ChangePasswordValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(register => register.Email).NotEmpty().EmailAddress().WithMessage("Email is required");

            RuleFor(Account => Account.OTP).NotEmpty().WithMessage("OTP is required");

            RuleFor(Account => Account.NewPassword).NotEmpty().WithMessage("Password is required")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{8,}$");

            RuleFor(Account => Account.ConfirmPassword)
                .Equal(register => register.NewPassword).WithMessage("Password Correct")
                .WithMessage("Passwords do not match");
        }
    }
}
