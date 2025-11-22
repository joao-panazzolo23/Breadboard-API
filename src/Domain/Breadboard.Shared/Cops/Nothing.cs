namespace Breadboard.Shared.Cops;

/// <summary>
/// This is a joke with VB.NET Null value, callen Nothing. Use this type to return Result<Nothing> instead of return Result<object> 
/// </summary>
public struct Nothing()
{
    public static readonly Nothing Value = new Nothing();
}