using Microsoft.EntityFrameworkCore;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Order> Orders { get; set; } 
        
        public DbSet<Product> Products { get; set; }    
        
        public DbSet<OrderDetail> OrderDetails { get; set; }    

    }
}
