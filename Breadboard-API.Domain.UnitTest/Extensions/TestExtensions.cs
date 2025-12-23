using System.Net;
using Breadboard.Shared.Results;
using FluentAssertions;

namespace Breadboard_API.Domain.Test.Extensions;

public static class TestExtensions
{
    public static void TestSuccess<T>(this Result<T> result)
    {
        result.IsSucess().Should().BeTrue();
    }
    
    public static void ShouldBe<T>(this Result<T> result, HttpStatusCode statusCode)
    {
        result.StatusCode.Should().Be((int)statusCode);
    }
    
}