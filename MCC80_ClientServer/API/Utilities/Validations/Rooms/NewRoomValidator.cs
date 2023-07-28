using API.Contracts;
using API.DTOs.Employees;
using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validation.Rooms
{
    public class NewRoomValidator : AbstractValidator<NewRoomDto>
    {
        private readonly IRoomRepository _roomRepository;
        public NewRoomValidator(IRoomRepository roomRepository)
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(100).WithMessage("Name more than maximum length");
            RuleFor(r => r.Floor)
                .NotEmpty();
            RuleFor(r => r.Capacity)
                .NotEmpty();
        }
    }
}
