using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public string CreateUser(int id, string name, string description)
        {
            bool result = _userService.Create(id, name, description);
            return result.ToString();
        }

        [HttpGet("{id}")]
        public string GetUser(int id)
        {
            User user = _userService.Get(id);

            return user.ToString();
        }

        [HttpGet]
        public string Get()
        {
            List<User> users = _userService.GetAll().ToList();
            string result = "";

            foreach (User user in users)
                result += user.ToString() + "\n";

            return result;
        }
    }
}
