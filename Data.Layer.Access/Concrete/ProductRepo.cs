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
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        private readonly DataAccess _context;

        public ProductRepo(DataAccess context):base(context)
        {
            _context = context;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(i=>i.Id == id);
            return await DeleteBase(product);
        }
    }
    }

