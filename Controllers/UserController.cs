using Microsoft.AspNetCore.Mvc;
using brokenaccesscontrol.Models;
using brokenaccesscontrol.Repositories;

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

        var user = UserRepository.Insert(userRequest);

        return new {
            user = user,
            message = user == null ? "Error" : "Success"
        };
    }    

}