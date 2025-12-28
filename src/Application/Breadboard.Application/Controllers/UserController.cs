using Breadboard.Application.Attributes;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Queries;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

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

    [HttpGet("[action]/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetUserQueryCommand>> GetById([FromRoute] GetUserQueryCommand command)
    {
        var response = await _cops.Dispatch<GetUserQueryCommand>(command);
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
}