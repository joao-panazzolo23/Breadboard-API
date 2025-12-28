using System.Reflection.Metadata.Ecma335;

namespace Breadboard.Domain.Users.Commands;

public record ChangePasswordCommand(
    Guid Id,
    string OldPassword,
    string NewPassword,
    string ConfirmPassword);