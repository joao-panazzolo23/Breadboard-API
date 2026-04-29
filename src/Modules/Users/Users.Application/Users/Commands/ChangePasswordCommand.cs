namespace Users.Application.Users.Commands;

public record ChangePasswordCommand(
    Guid Id,
    string OldPassword,
    string NewPassword,
    string ConfirmPassword);