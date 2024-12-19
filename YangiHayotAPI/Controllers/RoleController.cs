using Microsoft.AspNetCore.Mvc;
using YangiHayotAPI.DTOs;
using YangiHayotAPI.Data;
using YangiHayotAPI.Services;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IRoleService roleService;

        public RoleController(DataContext dataContext, IRoleService roleService)
        {
            _dataContext = dataContext;
            this.roleService = roleService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] RoleCreateRequest newRole)
        {
            var checkrole = this.roleService.GetByName(newRole.Name);
            if (checkrole != null) 
            {
                return BadRequest("This role already exists!");
            }
            int id = this.roleService.Create(newRole.Name);
            return Ok(id);

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var role = this.roleService.Index();
            return Ok(role);    
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var role = this.roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, string r_name)
        {
            var role = this.roleService.GetById(id);  
            if (role == null)
            {
                return NotFound("Role not found!");
            }

            var updatedRole = this.roleService.GetByName(r_name);
            if (updatedRole is null)
            {
              Role? newrole = this.roleService.Update(id,r_name);
               return Ok(newrole);
            }

            return BadRequest($"This role {updatedRole.Name} exists");  
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) 
        {
            this.roleService.Delete(id);
            return NoContent();
        }

    }
}
