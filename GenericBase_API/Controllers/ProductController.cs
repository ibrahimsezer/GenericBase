using Business.Layer.Access.Interface;
using Data.Layer.Access.DTO;
using Data.Layer.Access.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericBase_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinessService _productBusinessService;

        public ProductController(IProductBusinessService productBusinessService)
        {
            _productBusinessService = productBusinessService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProduct()
        {
            var getallproduct = await _productBusinessService.GetAllProduct();
            return Ok(getallproduct);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var getProduct = await _productBusinessService.GetProduct(id);
            return Ok(getProduct);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var createProduct = await _productBusinessService.CreateProduct(product);
            return Ok(createProduct);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)

        {
            await _productBusinessService.UpdateProduct(id, product);
            return Ok(product);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteByIdProduct(int id)
        {
            await _productBusinessService.DeleteProduct(id);
            return Ok();
        }


    }
}
