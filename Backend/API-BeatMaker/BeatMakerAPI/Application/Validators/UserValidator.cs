using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            // Rules for Username
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).NotNull();

            //Rules for Password
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.Password).NotNull();

            //Rules for Email
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).NotNull();
        }
    }
}
