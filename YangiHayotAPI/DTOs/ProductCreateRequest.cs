using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using YangiHayotAPI.Enums;

namespace YangiHayotAPI.DTOs
{
    public class ProductCreateRequest
    {
        [StringLength(55)]
        [Required]
        public string Name { get; set; } = string .Empty;
        
        [Required]
        [Range(1000,9999999)]
        public decimal Price { get; set; }
        [StringLength(22)]
        public ProductSizeEnum Size { get; set; }
        public IFormFile ? Photo { get; set; }
        [StringLength(35)]
        public double Quantity { get; set; }
    }
}
