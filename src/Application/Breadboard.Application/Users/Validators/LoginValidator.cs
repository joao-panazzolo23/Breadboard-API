using Breadboard.Application.Helpers;
using Breadboard.Application.Users.Commands;
using FluentValidation;

namespace Breadboard.Application.Users.Validators;

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