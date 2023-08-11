using Business.Layer.Access.Interface;
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
        public IActionResult GetId(int id)
        {
            var getuser = _businessService.GetById(id);
            return Ok(getuser);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var getall =_businessService.GetAll();
            return Ok(getall);
        }
    }
}
