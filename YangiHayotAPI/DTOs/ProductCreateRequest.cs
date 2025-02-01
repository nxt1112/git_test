using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using YangiHayotAPI.Enums;

namespace YangiHayotAPI.DTOs
{
    public class ProductCreateRequest
    {
        [StringLength(55)]
        
        public string Name { get; set; } = string .Empty;
        
        [Required]
        [Range(1000,9999999)]
        public decimal Price { get; set; }
        
        public ProductSizeEnum Size { get; set; }
        public IFormFile ? Photo { get; set; }
        
        public double Quantity { get; set; }
    }
}
