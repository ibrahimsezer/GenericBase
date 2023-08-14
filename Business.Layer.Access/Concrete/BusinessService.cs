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
        private readonly IBusinessService _bridgeService;

        public BusinessService(IBusinessService bridgeService)
        {
            _bridgeService = bridgeService;
        }

        public void Add(UserInfo entity)
        {
            _bridgeService.Add(entity);
        }

        public void Delete(UserInfo entity)
        {
            if (entity != null)
            {
                _bridgeService?.Delete(entity);
            }
            else throw new Exception("Error.");
        }

        public IEnumerable<UserInfo> GetAll()
        {
            return _bridgeService.GetAll();
        }

   

        public void Update(UserInfo entity)
        {
            _bridgeService.Update(entity);
        }

        Task<UserInfo> IBaseRepo<UserInfo>.GetById(int id)
        {
            if (id != null)
            {

                return _bridgeService.GetById(id);
            }
            else throw new Exception("Error, id not found");
        }
    }
}
