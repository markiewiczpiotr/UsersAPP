using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastStart.Entities;
using FastStart.Models;
using FluentValidation;

namespace FastStart.Validators
{
    public class UserValidatorDTO :AbstractValidator<CreateUsersDTO>
    {
        public UserValidatorDTO(UsersDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(8);

            RuleFor(x => x.ConfirmPassword).Equal(c => c.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
            {
                var EmailInUse = dbContext.Users.Any(u => u.Email == value);
                if (EmailInUse)
                {
                    context.AddFailure("Email", "That Email is taken");
                }
            });
            
            RuleFor(x => x.NrFBO)
                .NotEmpty();

            RuleFor(x => x.NrFBO)
                .Custom((value, context) =>
            {
                var EmailInUse = dbContext.Users.Any(u => u.NrFBO == value);
                if (EmailInUse)
                {
                    context.AddFailure("NrFBO", "That number is taken");
                }
            });

            RuleFor(x => x.NrTel)
                .NotEmpty();

            RuleFor(x => x.NrTel)
                .Custom((value, context) =>
                {
                    var EmailInUse = dbContext.Users.Any(u => u.NrTel == value);
                    if (EmailInUse)
                    {
                        context.AddFailure("NrTel", "That number is taken");
                    }
                });
        }
    }
}
