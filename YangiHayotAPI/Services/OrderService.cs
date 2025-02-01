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

        public List<Order> GetOrdersList() 
        {
            return _dataContext.Orders.ToList();    
        }

        public Order CreateNewOrder(decimal price, int userid)
        {
            Order order = new Order()
            {
                Price = price,
                UserId = userid,
            };
            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();
            return order;
        }

        public Order? GetOneOrder(int id)
        {
            return _dataContext.Orders.FirstOrDefault(o=>o.Id == id);   
        }

        public Order UpdateOrder(decimal price, Order order)
        {
            order.Price = price;
            _dataContext.SaveChanges();
            return order;
        }

        public void DeleteOrder(Order order) 
        {
            _dataContext.Orders.Remove(order);        
        }
    }
}
