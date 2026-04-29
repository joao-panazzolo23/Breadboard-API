using Breadboard.Domain.Users.Entities;

namespace Breadboard.Application.Authentication;

public interface IJwtProvider
{
     Task<string> Generate(User user);
}