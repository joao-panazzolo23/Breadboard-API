using System.Drawing;
using Breadboard.Application.Helpers;
using FluentValidation;
using Users.Application.Commands;

namespace Users.Application.Validators;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        var lst = ValidationHelpers.Fields<LoginCommand>(
            x => x.Password,
            x => x.Username
        );

        foreach (var exp in lst)
        {
            RuleFor(exp).NotEmpty();
        }
    }
}
