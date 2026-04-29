using FluentValidation;
using Users.Application.Commands;

namespace Users.Application.Validators;

public class UserPasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    //todo: validate if:
    //1. OldPassword is correct
    //2. Password doesn't match new password
    //search for a better way to use prop names
    public UserPasswordValidator()
    {
        RuleFor(z => z.NewPassword)
            .Matches(x => x.ConfirmPassword);

        RuleFor(z => z.OldPassword)
            .NotEqual(x => x.NewPassword);

        RuleFor(z => z.NewPassword)
            .Matches(x => x.NewPassword);
    }
}


// public class CreateOrderHandler(
//     IOrderRepository _repository,
//     IUnityOfWork _unity)
//     : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
// {
//
//     public async ValueTask<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
//     {
//         var order = request.Map(); // Mapping to entity
//         await _repository.Create(order);
//         
//         await _unity.Commit();
//         return ResultFactory<Unit>.Ok(result);
//     }
// }