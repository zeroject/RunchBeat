using Application.DTOs;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace Application.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Email).NotNull();
        }
    }
}
