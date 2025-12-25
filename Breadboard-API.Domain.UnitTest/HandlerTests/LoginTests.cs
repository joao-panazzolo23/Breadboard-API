using System.Net;
using Breadboard_API.Domain.Test.Extensions;
using Breadboard_API.Domain.Test.MockEntities;
using Breadboard.Domain.Services;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Handlers;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Results;
using FluentAssertions;
using Moq;
using Xunit.Abstractions;

namespace Breadboard_API.Domain.Test.HandlerTests;

public class LoginTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<IUserQueryRepository> _mockRepo = new();
    private readonly Mock<IJwtAuthService> _mockAuth = new();
    private readonly LoginCommand _command = new LoginCommand("john", "senha123", Token: "");
    private readonly UserViewmodel _user = MockUsers.Create("john").Generate();

    public LoginTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    private void _setup(UserViewmodel? user) => _mockRepo.Setup(r =>
            r.GetByUserName("john"))
        .ReturnsAsync(user);


    [Fact]
    public async Task LoginTest_ReturnsUser()
    {
        _setup(_user);

        var result = await Execute();

        _testOutputHelper.WriteLine(result.StatusCode.ToString());
        result.TestSuccess();

        // _mockAuth.Verify(a => a.Validate(It.IsAny<string>(),
        //         It.IsAny<string>()),
        //     Times.Once);
    }

    [Fact]
    public async Task LoginTest_UserNotFound()
    {
        _setup(null);

        //object returns the concrete class 
        var result = await Execute();

        result.IsSucess().Should().BeFalse();
        result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task LoginTest_Unauthorized()
    {
        _setup(_user);
        var result = await Execute();

        result.ShouldBe(HttpStatusCode.Unauthorized);
    }

    private async Task<Result<LoginViewmodel>> Execute()
    {
        // var handler = new LoginHandler(_mockRepo.Object, _mockAuth.Object);
        // return await handler.Handle(_command);

        throw new NotImplementedException();
    }
}