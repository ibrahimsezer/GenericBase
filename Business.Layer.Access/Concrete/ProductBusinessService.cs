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
    public class ProductBusinessService : IProductBusinessService
    {
        public readonly IProductRepo _productRepo;

        public ProductBusinessService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<Product> CreateProduct(Product product)
        {
            return _productRepo.CreateProduct(product);
        }

        public Task<Product> DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }
        public Task<List<Product>> GetAllProduct()
        {
            return _productRepo.GetAllProduct();
        }

        public Task<Product> GetProduct(int id)
        {
            return _productRepo.GetProduct(id);
        }
    }
}
