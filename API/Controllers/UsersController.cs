using API.Data;
using API.Entitites;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
            => Ok(await _userRepository.GetUsersAsync());
        // api/users/3 - get user under 3 id
        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUser(string username)
            => await _userRepository.GetUserByUsernameASync(username);

    }
}