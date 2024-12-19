using System.ComponentModel.DataAnnotations;

namespace YangiHayotAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public int UserId { get; set; } 
        public decimal Price { get; set; }  
    }
}
