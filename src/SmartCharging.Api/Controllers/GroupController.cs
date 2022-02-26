
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartCharging.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupController : ControllerBase
{
    public GroupController()
    {
        
    }
    // GET: /<controller>/
    public IActionResult Index()
    {
        return Ok();
    }
}


