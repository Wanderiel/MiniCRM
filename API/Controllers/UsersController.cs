using Application.Dtos.Users;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedUserDto userDto)
        {
            if (userDto.Password1 == userDto.Password2 == false)
                return BadRequest("Пароли не совпадают");

            await _userService.AddAsync(userDto);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<UserDto> users = await _userService.GetAllAsync();

            if (users == null || users.Count == 0)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDto? user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto userDto)
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
}
