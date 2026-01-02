using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Viewmodels;
using Mediator;

namespace Breadboard.Application.Users.Queries;

public record GetUserQueryCommand(Guid Id) : ICommand<Result<UserViewmodel>>;