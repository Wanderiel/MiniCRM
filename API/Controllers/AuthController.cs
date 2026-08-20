using Application.Dtos.Users;
using Application.Services;
using FluentValidation;
using FluentValidation.Results;
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
    public async Task<IActionResult> Register([FromBody] CreatedUserDto userDto, [FromServices] IValidator<CreatedUserDto> validator)
    {
        ValidationResult validationResult = validator.Validate(userDto);

        if (validationResult.IsValid == false)
            return UnprocessableEntity(validationResult.Errors);

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
