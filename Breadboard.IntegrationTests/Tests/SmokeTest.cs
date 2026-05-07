using Breadboard.IntegrationTests.Abstract;
using Breadboard.IntegrationTests.Configurations;
using Dapper;
using FluentAssertions;

namespace Breadboard.IntegrationTests.Tests;
/// <summary>
/// Minimal class just to test Docker & Containers 
/// </summary>
/// <param name="pg"></param>
public class SmokeTests(PostgresContainerFixture pg) : IntegrationTestBase(pg)
{
    [Fact]
    public async Task Database_ShouldBeReachable()
    {
        var result = await Db.ExecuteScalarAsync<int>("SELECT 1");
        result.Should().Be(1);
    }
}