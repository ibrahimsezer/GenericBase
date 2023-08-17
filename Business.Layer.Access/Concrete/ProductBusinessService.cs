using Business.Layer.Access.Interface;
using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;

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
        public Task<Product> UpdateProduct(int id,Product product)
        {
            return _productRepo.UpdateProduct(id,product);
        }
    }
}
