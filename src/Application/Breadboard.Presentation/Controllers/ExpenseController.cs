using Breadboard.Application.Cops.Abstractions;
using Breadboard.Presentation.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Controllers;

[AutoRouting]
[ApiController]
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