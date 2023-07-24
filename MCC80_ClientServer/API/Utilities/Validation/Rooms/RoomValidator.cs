using API.Contracts;
using API.DTOs.Accounts;
using API.DTOs.Rooms;
using FluentValidation;

namespace API.Utilities.Validation.Rooms
{
    public class RoomValidator : AbstractValidator<RoomDto>
    {
        private readonly IRoomRepository _roomRepository;
        public RoomValidator(IRoomRepository roomRepository)
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
