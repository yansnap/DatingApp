using API.Entitites;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
            => await _context.Users.FindAsync(id);
        

        public async Task<AppUser> GetUserByUsernameASync(string username)    
            => await _context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
            => await _context.Users
            .Include(p => p.Photos)
            .ToListAsync();
        

        public async Task<bool> SaveAllAsync()
            => await _context.SaveChangesAsync() > 0;
        

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}