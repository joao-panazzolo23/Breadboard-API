using Breadboard.Application.Attributes;
using Breadboard.Shared.Cops;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[AutoRouting]
[ApiController]
[ApiVersion("1")]
public class ExpenseController(ICops cops) : ControllerBase
{
    private readonly ICops _cops = cops;

    [HttpPost]
    public IActionResult Add()
    {
        // _bridge.Send<>()
        throw new NotImplementedException();
        //todo: if expense category is not registered, create one half-populated
    }
}