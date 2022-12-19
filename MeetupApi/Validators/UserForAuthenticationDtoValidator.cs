using Entities.Dtos;
using FluentValidation;

namespace MeetupApi.Validators
{
    public class UserForAuthenticationDtoValidator : AbstractValidator<UserForAuthenticationDto>
    {
        public UserForAuthenticationDtoValidator() 
        {
            string notNullOrEmptyMessage = "{PropertyName} field must be not null or empty.";
            RuleFor(u => u.UserName).NotNull().NotEmpty().WithMessage(notNullOrEmptyMessage);
            RuleFor(e => e.Password).NotNull().NotEmpty().WithMessage(notNullOrEmptyMessage);
        }
    }
}
