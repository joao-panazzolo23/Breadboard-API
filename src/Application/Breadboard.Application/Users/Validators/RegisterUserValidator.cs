using Breadboard.Application.ResultPattern;
using Breadboard.Application.Users.Commands;
using FluentValidation;

namespace Breadboard.Application.Users.Validators;

internal sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(Errors.InvalidEmail);

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Errors.InvalidUsername);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches(x => x.ConfirmPassword)
            .WithMessage(Errors.InvalidPassword(nameof(RegisterUserCommand.Password)));
    }
}