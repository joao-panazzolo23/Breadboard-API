namespace Breadboard.Application.ResultPattern.Models;

public static class Errors
{
    public static string InvalidEmail => "Invalid email address";
    public static string InvalidUsername => "Invalid username";
    public static string InvalidField(string propName) => $"Invalid input: {propName}";
}