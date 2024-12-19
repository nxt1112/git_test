using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public interface IOrderService
    {
        public int Create(DateTime CreatedAt, int UserId, decimal Price);
        
        public List<Order> Index();
        
        public Order Show(int Id);
        
        public string Update(int Id, DateTime CreatedAt,int UserId, decimal Price);
        
        public void Delete(int Id);   
    }
}
