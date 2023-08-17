using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Layer.Access.Concrete
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        private readonly DataAccess _context;
        public UserRepo(DataAccess context) : base(context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            return await CreateBase(user);
        }

        public async Task<User> DeleteUser(int id)
        {

            var user =  await _context.Users.FirstOrDefaultAsync(i=>i.Id==id);
            return await DeleteBase(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Products).ToListAsync();
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                return await GetUnit(user);
        }
    }
}
