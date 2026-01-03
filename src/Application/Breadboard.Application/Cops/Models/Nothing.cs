namespace Breadboard.Application.Cops.Models;

/// <summary>
/// This is a joke with VB.NET Null value, called Nothing.
/// Use this type to return Result<Nothing> instead of return Result<object>.
/// </summary>
public readonly struct Nothing()
{
    public static readonly Nothing Value = new();
}