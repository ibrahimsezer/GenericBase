using Business.Layer.Access.Interface;
using Data.Layer.Access.Entity;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public  async Task<IActionResult> GetIdAsync(int id)
        {
            var getid = await _businessService.GetById(id);
            return Ok();
        }
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    _businessService.GetAll();
        //    return Ok();
        //}

        [HttpDelete]
        public IActionResult DeleteById(int id) {
            UserInfo entity = new();
            entity.Id = id;
            _businessService.Delete(entity);
                return null; }
    }
}
