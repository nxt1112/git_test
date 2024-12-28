using System.ComponentModel.DataAnnotations;

namespace YangiHayotAPI.DTOs
{
    public class UserUpdateRequest
    {
        [Required]
        [MaxLength(10)]
        public int Id { get; set; } 


        [MaxLength(25)]
        [MinLength(2)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(40)]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [StringLength(8)]
        [Required]
        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
