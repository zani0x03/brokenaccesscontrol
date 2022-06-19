using Microsoft.AspNetCore.Mvc;

namespace brokenaccesscontrol.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{

    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }

// [HttpPost]
// [Route("login")]
// public async Task<dynamic> Login([FromBody]LoginRequest login)
// {
//     // Recupera o usuário
//     var user = UserRepository.Get(model.Username, model.Password);

//     // Verifica se o usuário existe
//     if (user == null)
//         return NotFound(new { message = "Usuário ou senha inválidos" });

//     // Gera o Token
//     var token = TokenService.GenerateToken(user);

//     // Oculta a senha
//     user.Password = "";
    
//     // Retorna os dados
//     return new
//     {
//         user = user,
//         token = token
//     };
// }


}