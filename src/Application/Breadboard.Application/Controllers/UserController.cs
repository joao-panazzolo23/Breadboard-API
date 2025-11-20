using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private ILightBridge _bridge { get; set; }
    public UserController(ILightBridge bridge)
    {
        _bridge = bridge;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ObjectResult> Login([FromBody] LoginCommand command)
    {
        var response = await _bridge.Send<LoginViewmodel>(command);
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
    public  async Task<IActionResult> UpdatePassword()
    {
        throw new NotImplementedException();
    }
}