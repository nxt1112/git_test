using System.ComponentModel.DataAnnotations;

namespace YangiHayotAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; } 
        public int OrderId { get; set; }    
        public decimal Price { get; set; }  
        public int ProductId { get; set; }  
    }
}
