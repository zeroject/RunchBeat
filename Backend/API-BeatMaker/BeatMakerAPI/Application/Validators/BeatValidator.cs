﻿using Application.DTOs;
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
            RuleFor(x => x.Summary).NotNull();

            //Rules for beatstring
            RuleFor(x => x.BeatString).NotNull();
            RuleFor(x => x.BeatString).NotEmpty();

            //Rules for email
            RuleFor(x => x.UserEmail).NotNull();
            RuleFor(x => x.UserEmail).NotEmpty();
        }
    }
}
