using Breadboard.Domain.Authentication;
using Breadboard.Domain.Users.Commands;
using FluentValidation;

namespace Breadboard.Application.Validators.User;

public class UserPasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    //todo: validate if:
    //1. OldPassword is correct
    //2. Password doesn't match new password
    //3. Pas
    public UserPasswordValidator(IPasswordHasher hasher)
    {
        RuleFor(z => z.NewPassword).Matches(x => x.ConfirmPassword);

        RuleFor(z => z.OldPassword).NotEqual(x => x.NewPassword);
        
        RuleFor(z => z.NewPassword).Matches(x => x.NewPassword);
        
    }
}