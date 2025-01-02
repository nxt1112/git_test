using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayotAPI.Data;
using YangiHayotAPI.Models;
using LoginRequest = YangiHayotAPI.DTOs.LoginRequest;

namespace YangiHayotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext dataContext;
        public AuthController(DataContext dataContext) 
        {
            this.dataContext = dataContext;

        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            User? user = dataContext.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user is null)
            {
                return BadRequest("Email is wrong");

            }


            bool passwordCheck = PasswordHelper.CheckPassword(request.Password, user.PasswordSalt, user.PasswordHash);
            if (passwordCheck is false)
            {
                return BadRequest("Password is wrong");
            }

            return Ok("Welcome");
        }



    }
}
