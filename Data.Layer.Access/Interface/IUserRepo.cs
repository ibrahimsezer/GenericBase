using Data.Layer.Access.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Interface
{
    public interface IUserRepo
    {

        Task<List<User>> GetAllUsers();
        Task<User> CreateUser(User user);
        Task<User> DeleteUser(int id);
        Task<User> GetUser(int id);

    }
}
