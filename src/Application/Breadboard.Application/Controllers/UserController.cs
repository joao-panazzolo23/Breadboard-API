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
public class UserController(ICops cops) : ControllerBase
{
    private readonly ICops _cops = cops;

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Result<LoginViewmodel>>> Login([FromBody] LoginCommand command)
    {
        var response = await _cops.Dispatch<LoginViewmodel>(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Register()
    {
        throw new NotImplementedException();
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

    [HttpPost]
    public Task<IActionResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdatePassword()
    {
        throw new NotImplementedException();
    }
}