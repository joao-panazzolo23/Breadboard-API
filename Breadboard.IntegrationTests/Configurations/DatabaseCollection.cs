namespace Breadboard.IntegrationTests.Configurations;

[CollectionDefinition("Database")]
public class DatabaseCollection : ICollectionFixture<PostgresContainerFixture> { }