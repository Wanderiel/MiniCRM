using Application.Dtos.Users;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly UsersService _userService;

    public UsersController(UsersService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetAll() =>
        await _userService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        UserDto? user = await _userService.GetAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatedUserDto userDto)
    {
        bool result = await _userService.UpdateAsync(id, userDto);

        if (result == false)
            return BadRequest();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _userService.DeleteAsync(id);

        if (result == false)
            return NotFound();

        return Ok();
    }
}
