using Breadboard.Application.Cops.Models;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.DTOs;
using Breadboard.Presentation.Shared.Attributes;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Users.Commands;
using Users.Application.Users.Queries;

namespace Users.Presentation;

[ApiController]
[AutoRouting] 
public class UserController(
    IMediator _mediator) : ControllerBase
{
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Result<LoginDto>>> Login([FromBody] LoginCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Nothing>> Register([FromBody] RegisterUserCommand command)
    {
        var response = await _mediator.Send(command);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDto?>> GetById([FromQuery] GetUserQueryCommand command)
    {
        var response = await _mediator.Send(command);
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
    public async Task<ActionResult<Nothing>> Delete(DeleteUserCommand command)
    {
        var result = await _mediator.Send(command);
        return StatusCode(result.StatusCode, result);
    }
}