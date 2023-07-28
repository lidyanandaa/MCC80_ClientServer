using API.Contracts;
using API.DTOs.Bookings;
using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validation.Bookings
{
    public class NewBookingValidator : AbstractValidator<NewBookingDto>
    {
        private readonly IBookingRepository _bookingRepository;
        public NewBookingValidator(IBookingRepository bookingRepository)
        {
            RuleFor(b => b.StartDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(b => b.EndDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(b => b.StartDate.AddHours(1));
            RuleFor(b => b.Status)
                .NotNull()
                //diambil dari utilities/enum/statuslevel.cs
                .IsInEnum();
            RuleFor(b => b.Remarks)
                .NotEmpty();
            RuleFor(b => b.RoomGuid)
                .NotEmpty();
            RuleFor(b => b.EmployeeGuid)
                .NotEmpty();
        }
    }
}
