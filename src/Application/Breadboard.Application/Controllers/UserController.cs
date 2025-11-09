using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        //todo: authentication service
        throw new NotImplementedException();
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
    public IActionResult UpdatePassword()
    {
        throw new NotImplementedException();
    }
}