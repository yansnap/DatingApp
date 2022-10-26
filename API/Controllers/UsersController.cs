using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
            => await _context.Users.ToListAsync();
        // api/users/3 - get users under 3 id
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
            => await _context.Users.FindAsync(id);
        
    }
}