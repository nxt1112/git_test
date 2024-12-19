using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace YangiHayotAPI.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
    }
}
