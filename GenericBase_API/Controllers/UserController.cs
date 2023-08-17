using Business.Layer.Access.Interface;
using Data.Layer.Access.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GenericBase_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusinessService _businessService;

        public UserController(IUserBusinessService businessService)
        {
            _businessService = businessService;
        }

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
        public async Task<IActionResult> DeleteByIdUser(int id)
        {

            await _businessService.DeleteBusinessUser(id);
            return Ok();
        }
    }
}
