﻿using Business.Layer.Access.Interface;
using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Access.Concrete
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserRepo _userRepo;

   

        public UserBusinessService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public Task<User> CreateBusinessUser(User user)
        {
            return _userRepo.CreateUser(user);
        }
        public Task<User> DeleteBusinessUser(int id)
        {
         
            return _userRepo.DeleteUser(id);
        }

        public Task<List<User>> GetAllUser()
        {
            return _userRepo.GetAllUsers();
        }
        public Task<User> GetUser(User user)
        {
            return _userRepo.GetUser(user);
        }


    }
}