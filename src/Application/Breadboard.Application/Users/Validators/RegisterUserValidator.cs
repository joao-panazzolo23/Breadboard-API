using Breadboard.Application.ResultPattern;
using Breadboard.Application.ResultPattern.Models;
using Breadboard.Application.Users.Commands;
using FluentValidation;

namespace Breadboard.Application.Users.Validators;

public sealed class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(Errors.InvalidEmail);

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage(Errors.InvalidUsername);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .WithErrorCode("400")
            .Equal(x => x.ConfirmPassword) 
            .WithMessage(Errors.InvalidField(nameof(RegisterUserCommand.Password)));
    }
}