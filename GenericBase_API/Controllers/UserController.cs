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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getalluser = await _businessService.GetAllUser();
            return Ok(getalluser);
        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var getuser = await _businessService.GetUser(id);
            return Ok(getuser);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser(User user)
        {
            var createUser = await _businessService.CreateBusinessUser(user);
            return Ok(createUser);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id , User user)
        {
            await _businessService.UpdateBusinessUser(id, user);
            return Ok(user);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteByIdUser(int id)
        {
            await _businessService.DeleteBusinessUser(id);
            return Ok();
        }

    }
}
