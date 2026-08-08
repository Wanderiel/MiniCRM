using Application.Dtos.Users;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService) =>
        _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreatedUserDto userDto)
    {
        await _authService.Register(userDto);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
    {
        if (await _authService.Login(loginUser) == false)
            return BadRequest("Неверное имя пользователя или пароль.");

        return Ok("Добро пожаловать!");
    }
}
