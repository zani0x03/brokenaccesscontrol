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

        try{
            // Recupera o usuário
            var user = await UserRepository.Login(login);


            // Verifica se o usuário existe
            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "User/Password not found!"
                });
            }

            user.Password = "";  
            var token = TokenService.GenerateToken(user);
            return Ok(new
            {
                User = user,
                token = token
            });              
        }catch(Exception ex){
            _logger.LogError(ex, "General error");
            return StatusCode(500, "Internal server error");            
        }
    }
}