using Breadboard.Domain.Users.Entities;

namespace Breadboard.Domain.Services;

public interface IJwtProvider
{
     Task<string> Generate(User user);
}