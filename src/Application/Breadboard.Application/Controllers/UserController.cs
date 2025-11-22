using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private ICops _cops { get; set; }
    public UserController(ICops cops)
    {
        _cops = cops;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ObjectResult> Login([FromBody] LoginCommand command)
    {
        var response = await _cops.Dispatch<LoginViewmodel>(command);
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost("register")]
    public IActionResult Register()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("update-password")]
    public async Task<IActionResult> UpdatePassword()
    {
        throw new NotImplementedException();
    }
}