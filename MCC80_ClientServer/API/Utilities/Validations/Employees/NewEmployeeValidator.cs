using API.Contracts;
using API.DTOs.Employees;
using FluentValidation;

namespace API.Utilities.Validation.Employees
{
    public class NewEmployeeValidator : AbstractValidator<NewEmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public NewEmployeeValidator(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;

            /* RuleFor(e => e.Nik)
                 .NotEmpty()
                 .MaximumLength(6);*/

            RuleFor(e => e.FirstName)
                .NotEmpty()
                .MaximumLength(100).WithMessage("First Name more than maximum length");

            RuleFor(e => e.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.AddYears(-10));

            RuleFor(e => e.Gender)
                .NotNull()
                //diambil dari utilities/enum/genderlevel.cs
                .IsInEnum();

            RuleFor(e => e.HiringDate)
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                //panggil method IsDDuplicationValue agar data tidak ada yg sama
                .Must(IsDuplicationValue).WithMessage("Email already exist");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20)
                //membuat karakter nomor agar inputan awal memkai kode negara +62, menggunakan regex
                .Matches(@"^\+[0-9]")
                //panggil method IsDDuplicationValue agar data tidak ada yg sama
                .Must(IsDuplicationValue).WithMessage("Phone number already exist");
        }

        //agar data tidak ada yg duplikasi, untuk email dan password
        private bool IsDuplicationValue(string arg)
        {
            return _employeeRepository.isNotExist(arg);
        }
    }
}
