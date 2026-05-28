using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            bool result = _userService.Create(name);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User user = await _userService.GetAsync(id);

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
