using Data.Layer.Access;
using Data.Layer.Access.DTO;
using Data.Layer.Access.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericBase_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDTOController : ControllerBase
    {
        private readonly DataAccess _context;

        public ProductDTOController(DataAccess context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet("productDTO/GetProducts")]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Category = p.Category
            }).ToList();

            return products;
        }


        // POST: api/products
        [HttpPost("productDTO/Create")]
        public  ActionResult<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                ProductName = productDTO.ProductName,
                Category = productDTO.Category
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            // DTO'yu oluşturulan ürünün kimliği ile güncelleyerek dönebilirsiniz
            productDTO.Id = product.Id;

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, productDTO);
        }

        ////// PUT: api/products/{id}
        //[HttpPut("{productDTO/Update}")]
        //public IActionResult UpdateProduct(int id, ProductDTO productDTO)
        //{
        //    var product = _context.Products.FirstOrDefault(p => p.Id == id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    product.ProductName = productDTO.ProductName;
        //    product.Category = productDTO.Category;

        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //// DELETE: api/products/{id}
        //[HttpDelete("{productDTO/Delete}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    var product = _context.Products.FirstOrDefault(p => p.Id == id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}

