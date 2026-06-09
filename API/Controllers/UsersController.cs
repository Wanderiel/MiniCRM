using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string username, string email, string firsName, string lastName, string password, string passwrord2)
        {
            if (password == passwrord2 == false)
                return Content("Пароли не совпадают");

            User user = new User()
            {
                Username = username,
                Email = email,
                FirstName = firsName,
                LastName = lastName,
                //CreatedAt = DateTime.UtcNow,
                //UpdatedAt = DateTime.UtcNow,
            };

            await _userService.AddAsync(user, password);

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
    }
}
