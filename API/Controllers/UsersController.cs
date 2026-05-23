using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public string Create(string name)
        {
            bool result = _userService.Create(name);
            return result.ToString();
        }

        [HttpGet("{id}")]
        public async Task<User> GetUser(int id) =>
            await _userService.GetAsync(id);

        [HttpGet]
        public async Task<List<User>> GetAll() =>
            await _userService.GetAllAsync();
    }
}
