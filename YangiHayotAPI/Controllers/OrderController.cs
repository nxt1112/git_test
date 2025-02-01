using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayotAPI.Models;
using YangiHayotAPI.Services;

namespace YangiHayotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;  

        public OrderController(IOrderService orderService, IUserService userService) 
        {
            this.orderService = orderService;
            this.userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Order> orders = this.orderService.GetOrdersList();
            return Ok(orders);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(decimal price, int userid)
        {
            User? user = this.userService.GetById(userid);

            if (user == null)
            {
                return BadRequest($"User not found with {userid}");
            }
            Order order = this.orderService.CreateNewOrder(price, userid);
            return Ok(order);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Show(int id)
        {
            Order? order = this.orderService.GetOneOrder(id);
            if (order == null) 
            {
                return NotFound();
            }
            return Ok(order);   
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, decimal price)
        {
            var oldOrder= this.orderService.GetOneOrder(id);
            if(oldOrder == null)
            {
                return BadRequest();
            }
            Order order= this.orderService.UpdateOrder(price, oldOrder);
            return Ok(order);   
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Order? order = this.orderService.GetOneOrder(id);
            if (order != null) 
            {
                this.orderService.DeleteOrder(order);
            }
            return NoContent();
        }   
    }
}
