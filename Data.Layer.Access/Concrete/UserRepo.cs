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
            var user = await _context.Users.Include(u => u.Products).FirstOrDefaultAsync(i => i.Id == id);
            if (user != null)
            {
                if (user.Products != null)
                {
                    foreach (var product in user.Products)
                    {
                        _context.Products.Remove(product);

                    }
                }
               
                //_context.Users.Remove(user);
                //await _context.SaveChangesAsync();
                //return null;
                return await DeleteBase(user);
                
            }

            else return await DeleteBase(user);
           
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
        public async Task<User> UpdateUser(int id, User user)
        {
            var updateUser = await _context.Users.FindAsync(id);
            updateUser.Name = user.Name;
            updateUser.Surname = user.Surname;
            updateUser.Information = user.Information;
            updateUser.Products = user.Products;
            return await UpdateBase(updateUser);
        }
    }
}
