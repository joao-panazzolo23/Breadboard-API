using Breadboard.Domain.Users.Commands;
using FluentValidation;

namespace Breadboard.Application.Validators.User;

internal sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Invalid email address");

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password length must be at least 8 characters long")
            .Matches(x => x.ConfirmPassword)
            .WithMessage("Passwords must match");
    }
}