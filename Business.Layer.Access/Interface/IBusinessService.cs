using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Access.Interface
{
    public interface IBusinessService
    {
        Task<List<User>> GetAllUser();
        Task<User> CreateUser(User user);

    }
}
