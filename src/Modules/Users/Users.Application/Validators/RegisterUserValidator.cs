using FluentValidation;
using Users.Application.Commands;

namespace Users.Application.Validators;

public sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Username)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .WithErrorCode("400")
            .Equal(x => x.ConfirmPassword);
    }
}