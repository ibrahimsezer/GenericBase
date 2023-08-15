using Business.Layer.Access.Interface;
using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Access.Concrete
{
    public class BusinessService : IBusinessService
    {
        private readonly IProductRepo _productRepo;

        public BusinessService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<User> CreateUser(User user)
        {
            return _productRepo.CreateUser(user);
        }

        public Task<List<User>> GetAllUser()
        {
            return _productRepo.GetAllUsers();
        }
    }
}
