using System.Net;
using Breadboard.Application.ResultPattern;
using FluentAssertions;

namespace Breadboard_API.Domain.Test.Extensions;

internal  static class TestExtensions
{
    internal static void TestSuccess<T>(this Result<T> result)
    {
        result.IsSucess().Should().BeTrue();
    }
    
    internal static void ShouldBe<T>(this Result<T> result, HttpStatusCode statusCode)
    {
        result.StatusCode.Should().Be((int)statusCode);
    }
    
}