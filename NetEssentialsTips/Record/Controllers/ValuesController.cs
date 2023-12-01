using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Record.Dtos;

namespace Record.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ValuesController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult Login(LoginDto loginDto)
        {
            //LoginDto loginDto2 = new()
            //{
            //    Email = "baris@baris.com",
            //    Password = "123"
            //};
            return Ok("login successfully.");
        }

        [HttpPost("[action]")]
        public IActionResult LoginWithRecord(Login login)
        {
            //you can not change record value once the created one time.
            return Ok("login successfully.");
        }
    }
}
