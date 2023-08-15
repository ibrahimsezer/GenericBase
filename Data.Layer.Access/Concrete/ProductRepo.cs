using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Concrete
{
    public class ProductRepo : BaseRepo<User>,IProductRepo
    {
        private readonly DataAccess _context;
        public ProductRepo(DataAccess context):base(context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            return await Create(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Products).ToListAsync();
        }
    }
}
