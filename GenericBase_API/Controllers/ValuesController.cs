using Business.Layer.Access.Interface;
using Data.Layer.Access.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GenericBase_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public ValuesController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        //[HttpGet]
        //public  async Task<IActionResult> GetIdAsync(int id)
        //{
        //    var getid = await _businessService.GetById(id);
        //    return Ok();
        //}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getalluser = await _businessService.GetAllUser();
            return Ok(getalluser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var createUser = await _businessService.CreateBusinessUser(user);
            return Ok(createUser);
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteById(int id)
        {

            await _businessService.DeleteBusinessUser(id);
            return Ok();
        }

        //product
        //[HttpDelete("product")]
        //public async Task<IActionResult> DeleteProductById(int id)
        //{
        //    await _businessService.DeleteBusinessProduct(id);
        //    return Ok();
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetUser(User user)
        //{
        //    var getuser = await _businessService.GetUser(user);
        //    return Ok(getuser);
        //}
    }
}
