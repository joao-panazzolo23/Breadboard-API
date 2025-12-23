using Bogus;
using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Viewmodels;

namespace Breadboard_API.Domain.Test.MockEntities;

public static class MockUsers
{
    /// <summary>
    /// Username needs to be the same as passed through parameters within IUserRepository, otherwise, returns not found.
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public static Faker<UserViewmodel> Create(string username) =>
        new Faker<UserViewmodel>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.Username, f => username)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => f.Internet.Password());
}