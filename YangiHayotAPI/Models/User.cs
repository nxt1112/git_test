﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YangiHayotAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } 
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32]; 
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int RoleId   { get; set; }
        
        public Role? Role { get; set; } 

    }
}
