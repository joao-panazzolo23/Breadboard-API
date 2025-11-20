using Breadboard.Shared.LightBridge;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[Route("api/v1/[controller]")]
public class ExpenseController(ILightBridge bridge) : ControllerBase
{
    private readonly ILightBridge _bridge = bridge;
    
    [HttpPost]
    public IActionResult Add()
    {
        // _bridge.Send<>()
        throw new NotImplementedException();
        //todo: if expense category is not registered, create one half-populated
    }
}