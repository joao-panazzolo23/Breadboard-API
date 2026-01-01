using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Commands;
using FluentValidation;

namespace Breadboard.Application.Users.Validators;

public class UserPasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    //todo: validate if:
    //1. OldPassword is correct
    //2. Password doesn't match new password
    //search for a better way to use prop names
    public UserPasswordValidator()
    {
        RuleFor(z => z.NewPassword)
            .Matches(x => x.ConfirmPassword)
            .WithMessage(Errors.InvalidPassword(nameof(ChangePasswordCommand.ConfirmPassword)));

        RuleFor(z => z.OldPassword)
            .NotEqual(x => x.NewPassword)
            .WithMessage(Errors.InvalidPassword(nameof(ChangePasswordCommand.NewPassword)));

        RuleFor(z => z.NewPassword)
            .Matches(x => x.NewPassword)
            .WithMessage(Errors.InvalidPassword(nameof(ChangePasswordCommand.NewPassword)));
    }
}