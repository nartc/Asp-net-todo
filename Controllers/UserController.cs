using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.Models.RequestParams;
using Task.Services;

namespace Task.Controllers
{
    [Route("api/users")]
    public class UserController: Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] NewUserParams newUser)
        {
            var user = await _userService.RegisterUser(newUser);
            return new OkObjectResult(user);
        }
    }
}