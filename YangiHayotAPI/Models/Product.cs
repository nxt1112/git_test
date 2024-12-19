using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace YangiHayotAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }   
        public string Size { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public double Quantity { get; set; }
        
    }
}
