using ContactsManager.Models;
using ContactsManager.Models.DTOs;
using ContactsManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserInterface _icontext;

        public AuthenticationController(IUserInterface icontext)
        {
            _icontext = icontext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto login)
        {
            var logn = await _icontext.Login(login);
            return (logn);
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Regiter(UserModel user)
        {
            var token = await _icontext.Regiter(user);
            return (token);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> ListUsers()
        {
            var users = await _icontext.ListUsers();
            return Ok(users);
        }
    }
}
