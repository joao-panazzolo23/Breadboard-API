using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Controllers;

[Route("api/v1/[controller]")]
public class ExpenseController : ControllerBase
{
    public ExpenseController()
    {
        
    }

    [HttpPost]
    public IActionResult Add()
    {
        throw new NotImplementedException();
        //todo: if expense category is not registered, create one half-populated
    }
}