using API.Data;
using API.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
            => await _context.Users.ToListAsync();

        // api/users/3 - get user under 3 id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
            => await _context.Users.FindAsync(id);
        
    }
}