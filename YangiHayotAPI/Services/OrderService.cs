using YangiHayotAPI.Data;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public class OrderService : IOrderService   
    {
        private readonly DataContext _dataContext;
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

        public int Create(DateTime CreatedAt, int UserId, decimal Price)
        {
            Order order = new Order()
            {
                CreatedAt = CreatedAt,
                UserId = UserId,
                Price = Price
            };
            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();
            return order.Id;    
        }

        public List<Order> Index() 
        {
            return _dataContext.Orders.ToList();
        }

        public Order Show(int Id)
        {
            var order = _dataContext.Orders.FirstOrDefault(o=>o.Id == Id);   
            return order;
        }

        public string Update(int Id, DateTime CreatedAt,int UserId, decimal Price)
        {
            var order = _dataContext.Orders.FirstOrDefault(o => o.Id == Id);
            if (order != null)
            {
                return "Not Found!";
            }
            order.Price = Price;
            order.CreatedAt = CreatedAt;
            order.UserId = UserId;
            _dataContext.SaveChanges();
            return "Updated!";
        }

        public void Delete(int Id) 
        {
            var order = _dataContext.Users.FirstOrDefault(o => o.Id == Id);
            if (order is not null)
            {
                _dataContext.Users.Remove(order);
                _dataContext.SaveChanges();
            }
        }
    }
}
