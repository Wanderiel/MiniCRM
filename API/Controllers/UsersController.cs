using API.Dtos;
using API.Extensions;
using Domain.Models;
using Domain.Services;
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
        public async Task<IActionResult> Create(CreatedUserDto userDto)
        {
            if (userDto.Password1 == userDto.Password2 == false)
                return BadRequest("Пароли не совпадают");

            User user = userDto.ToEntity();
            await _userService.AddAsync(user, userDto.Password1);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User? user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = await _userService.GetAllAsync();

            if (users == null || users.Count == 0)
                return NotFound();

            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
        {
            User? user = await _userService.UpdateAsync(id, userDto.ToEntity());

            if (user == null)
                return NotFound();

            return Ok(user);
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
