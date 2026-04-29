namespace Users.Application.Commands;

public record ChangePasswordCommand(
    Guid Id,
    string OldPassword,
    string NewPassword,
    string ConfirmPassword);