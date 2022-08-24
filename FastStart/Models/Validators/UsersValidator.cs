/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastStart.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FastStart.Models.Validators
{
    public class UsersValidator : AbstractValidator<CreateUsersDTO>
    {
        public UsersValidator(UsersDbContext context)
        {
            RuleFor(x => x.eMail)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(8);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.eMail)
                .Custom((value, context) =>
                {
                    var eMailInUse = context.Users.Any(u => u.eMail == value);
                    if (eMailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }

                });
        }
    }
}
*/