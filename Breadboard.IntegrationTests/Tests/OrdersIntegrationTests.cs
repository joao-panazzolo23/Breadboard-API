using Breadboard.IntegrationTests.Abstract;
using Breadboard.IntegrationTests.Configurations;

namespace Breadboard.IntegrationTests.Tests;

[Collection("Database")]
public class OrdersIntegrationTests(
    PostgresContainerFixture pg
) : IntegrationTestBase(pg)
{
    protected override string[] Schemas => ["orders"];
}