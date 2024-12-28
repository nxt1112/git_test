using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayotAPI.Data;
using YangiHayotAPI.DTOs;
using YangiHayotAPI.Models;
using YangiHayotAPI.Services;

namespace YangiHayotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _datacontext;
        private readonly IUserService userService;

        public UserController(DataContext dataContext, IUserService userService)
        {
            _datacontext = dataContext;
            this.userService = userService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] UserCreateRequest newUser)
        {
            if(int.TryParse(newUser.FirstName, out int result))
            {
                return UnprocessableEntity();
            }
            int id = this.userService.Create(newUser.FirstName, newUser.LastName, newUser.PhoneNumber, newUser.Email, newUser.Password,newUser.RoleId);
            return Ok(id);
        }

        [HttpGet]
        [Route("")]
        public  IActionResult Index()
        {
            var user = this.userService.Index();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = this.userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(UserUpdateRequest update)
        {
            var user = this.userService.GetById(id);
            if (user is null)
            {
                return NotFound("Not Found!");
            }
            this.userService.Update(update.Id, update.FirstName, update.LastName, update.PhoneNumber, update.Email, update.Password, update.RoleId);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            this.userService.Delete(id);
            return NoContent();
        }
    }
}
