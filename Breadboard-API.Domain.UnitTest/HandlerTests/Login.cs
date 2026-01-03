using System.Net;
using Breadboard_API.Domain.Test.Extensions;
using Breadboard_API.Domain.Test.MockEntities;
using Breadboard.Application.Authentication;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.Users.Commands;
using Breadboard.Application.Users.Handlers;
using Breadboard.Application.Users.Repositories;
using Breadboard.Domain.Users.DTOs;
using Breadboard.Domain.Users.Entities;
using FluentAssertions;
using Moq;

namespace Breadboard_API.Domain.Test.HandlerTests;
// ITestOutputHelper _console
public class Login
{
    private readonly Mock<IUserRepository> _mockRepo = new();
    private readonly Mock<IJwtAuthService> _mockAuth = new();
    private readonly Mock<IPasswordHasher> _mockPass = new();
    private readonly LoginCommand _command = new LoginCommand("john", "senha123");

    private void _setup(User? user) => _mockRepo.Setup(r =>
            r.GetByUsername("john"))
        .ReturnsAsync(user);


    private User? GetUser()
    {
        return MockUsers.CreateUser("john", "senha123").Generate();
    }

    [Fact]
    public async Task Login_ReturnsUser()
    {
        var hash = "HASH_OK";
        var pass = "senha123";

        _mockPass
            .Setup(p => p.Hash(pass))
            .Returns(hash);

        _mockPass
            .Setup(p => p.Verify(pass, hash))
            .Returns(true);

        var user = MockUsers.CreateUser("john", hash).Generate();

        _setup(user);

        var result = await Execute();

        result.TestSuccess();
        result.Data.Should().NotBeNull();
    }


    [Fact]
    public async Task Login_UserNotFound()
    {
        _setup(null);

        var result = await Execute();

        result.IsSucess().Should().BeFalse();
        result.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task LoginTest_Unauthorized()
    {
        var user = GetUser();

        _setup(user);
        var result = await Execute();

        result.ShouldBe(HttpStatusCode.Unauthorized);
    }

    private async Task<Result<LoginDto>> Execute()
    {
        var handler = new LoginHandler(_mockRepo.Object, _mockAuth.Object, _mockPass.Object);
        return await handler.Handle(_command, CancellationToken.None);
    }
}