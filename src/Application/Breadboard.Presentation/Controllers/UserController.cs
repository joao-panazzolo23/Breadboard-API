using Breadboard.Application.Cops;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Queries;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Presentation.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Controllers;

[ApiController]
[AutoRouting]
public class UserController(ICops _cops) : ControllerBase
{
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Result<LoginViewmodel>>> Login([FromBody] LoginCommand command)
    {
        var response = await _cops.Dispatch<LoginViewmodel>(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Nothing>> Register(RegisterUserCommand command)
    {
        var response = await _cops.Dispatch<Nothing>(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserViewmodel?>> GetById([FromQuery] GetUserQueryCommand command)
    {
        var response = await _cops.Dispatch<UserViewmodel?>(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public Task<IActionResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdatePassword()
    {
        throw new NotImplementedException();
    }

    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("[action]")]
    public async Task<ActionResult<Nothing>> UpdatePassword(DeleteUserCommand command)
    {
        var result = await _cops.Dispatch<Nothing>(command);
        return StatusCode(result.StatusCode, result);
    }
}