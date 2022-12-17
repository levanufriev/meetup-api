using Entities.Dtos;
using FluentValidation;

namespace MeetupApi.Validators
{
    public class EventForCreationDtoValidator : AbstractValidator<EventForCreationDto>
    {
        public EventForCreationDtoValidator()
        {
            string notNullOrEmptyMessage = "{PropertyName} field must be not null or empty.";
            RuleFor(e => e.Theme).NotNull().NotEmpty().WithMessage(notNullOrEmptyMessage);
            RuleFor(e => e.Description).NotNull().NotEmpty().WithMessage(notNullOrEmptyMessage);
            RuleFor(e => e.Speaker).NotNull().NotEmpty().WithMessage(notNullOrEmptyMessage);
            RuleFor(e => e.Date).NotNull().Must(x => x > DateTime.UtcNow).WithMessage("Date must be greater than now.");
            RuleFor(e => e.Place).NotNull().NotEmpty().WithMessage(notNullOrEmptyMessage);
        }
    }
}
