using brokenaccesscontrol.Models;
using brokenaccesscontrol.Repositories;
using brokenaccesscontrol.Services;
using Microsoft.AspNetCore.Mvc;

namespace brokenaccesscontrol.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{

    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody]LoginRequest login)
    {
        // Recupera o usuário
        var user = await UserRepository.Login(login);


        // Verifica se o usuário existe
        if (user == null)
        {
            return Unauthorized(new
            {
                message = "User not found!"
            });
        }

        if (user.Password == UtilService.ReturnSha512(login.Password)){
            if (login.IsAdmin.HasValue)
                user.IsAdmin = login.IsAdmin.Value;
            user.Password = "";  
            var token = TokenService.GenerateToken(user);
            return Ok(new
            {
                User = user,
                token = token
            });              

        }
        else{
            return Unauthorized(new
            {
                message = "Wrong password!!!"
            });    
        }
    }
}