using Microsoft.AspNetCore.Mvc;
using brokenaccesscontrol.Models;

namespace brokenaccesscontrol.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<dynamic>> Register([FromBody]UserRequest userRequest)
    {

        return new {
            user = userRequest,
            message = "success"
        };
    }    

}