using Breadboard.Application.ResultPattern;
using Breadboard.Domain.DTOs;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Presentation.Attributes;
using Users.Application.Commands;
using Users.Application.Queries;

namespace Users.Presentation;

[ApiController]
[AutoRouting]
public class UserController(
    IMediator mediator
) : ControllerBase
{
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Result<LoginDto>>> Login([FromBody] LoginCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Unit>> Register([FromBody] RegisterUserCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDto?>> GetById([FromQuery] GetUserQueryCommand command)
    {
        var response = await mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public Task<IActionResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Unit>> Delete([FromRoute] Guid userId)
    {
        var command = new DeleteUserCommand()
        {
            Id = userId
        };
        var result = await mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }
}