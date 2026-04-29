namespace BuildingBlocks.PostgreSQLDapper.Abstractions;

/// <summary>
/// Marker interface for injecting dependencies automatically.
/// 
/// Unfortunately, we cant use IDbConnection since it is a Dapper concrete class,
/// it would break Domain completely by referring to infrastructure directly.
/// 
/// Martin Fowler (Repository pattern) and also Microsoft .NET team says it's fine to have marker interfaces.
/// 
/// Eric Evans e Vaughn Vernon (DDD) mention marker interfaces in contexts like: IEntity, IDomainEvent
/// used to identify classes during runtime with reflections.
///
/// It is really a design pattern, not a design flaw or a temporary workaround.
///  
/// GOF condemns function-less interfaces only when they DON'T HAVE AN ACTUAL PURPOSE.
/// 
/// In this case, it does have a purpose: Search for concrete implementations within infrastructure
/// and inject dependencies through domain without the real need to declare which one is which (automatic discover)
/// </summary>
public interface IQueryRepository { }