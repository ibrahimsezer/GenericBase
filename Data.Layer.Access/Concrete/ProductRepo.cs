using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Access.Concrete
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly DataAccess _context;

        public ProductRepo(DataAccess context):base(context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await CreateBase(product);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(i=>i.Id == id);
            return await DeleteBase(product);
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product =  await _context.Products.FirstOrDefaultAsync(u=>u.Id ==id);
            return await GetUnit(product);
        }
        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var updateProduct = await _context.Products.FindAsync(id);
            updateProduct.ProductName = product.ProductName;
            updateProduct.Category = product.Category;
            return updateProduct;
        }
    }
    }

