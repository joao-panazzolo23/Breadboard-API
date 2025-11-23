using Breadboard.Application.Attributes;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[ApiController]
[ControllerRoute]
[DynamicVersion]
public class UserController(ICops cops) : ControllerBase
{
    private ICops _cops { get; set; } = cops;

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ObjectResult> Login([FromBody] LoginCommand command)
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
    
    [HttpPost]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdatePassword()
    {
        throw new NotImplementedException();
    }
}