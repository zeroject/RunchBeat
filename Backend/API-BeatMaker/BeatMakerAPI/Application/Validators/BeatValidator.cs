using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class BeatValidator : AbstractValidator<BeatDTO>
    {
        public BeatValidator()
        {
            //Rules for title
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Title).NotEmpty();
            
            //Rules for summary
            RuleFor(x => x.Title).NotNull();

            //Rules for beatstring
            RuleFor(x => x.Title).NotNull();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
