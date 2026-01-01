namespace Breadboard.Application.ResultPattern;

public static class Errors
{
    public static string InvalidEmail => "Invalid email address";
    public static string InvalidUsername => "Invalid username";
    public static string InvalidPassword(string propName) => $"Invalid property: {propName}";
}