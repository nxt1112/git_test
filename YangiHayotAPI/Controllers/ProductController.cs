using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System.Runtime.CompilerServices;
using YangiHayotAPI.Data;
using YangiHayotAPI.DTOs;
using YangiHayotAPI.Enums;
using YangiHayotAPI.Models;
using YangiHayotAPI.Services;

namespace YangiHayotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IProductService productService;

        public ProductController(DataContext dataContext, IProductService productService)
        {
            _dataContext = dataContext;
            this.productService= productService;    
        }
        [HttpPost]
        [Route("")]
        public IActionResult Create([FromForm] ProductCreateRequest newProduct)
        {
            var checkproduct = this.productService.GetByName(newProduct.Name);
            if (checkproduct != null)
            {
                return BadRequest("This product already exists!");
            }
            int id = this.productService.Create(newProduct.Name, newProduct.Price, newProduct.Size, newProduct.Photo, newProduct.Quantity);

            


            FileStream fs = new FileStream("wwwroot/" + newProduct.Photo.FileName, FileMode.Create);

            newProduct.Photo.CopyTo(fs);

            fs.Dispose();
            
            return Ok(id);

        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var product = this.productService.Index();
            return Ok(product); 
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Show(int id)
        {
            var product = this.productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, string Name, decimal Price, ProductSizeEnum Size, IFormFile Photo, double Quantity)
        {
            var product = this.productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            var updatedProduct = this.productService.GetByName(Name);
            if (updatedProduct is null)
            {
                Product? newProduct = this.productService.Update(id, Name, Price, Size, Photo, Quantity);
                return Ok(newProduct);
            }
            return BadRequest($"This product already exsists!");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            this.productService.Delete(id);
            return NoContent();
        }
    }
}
