using System.Runtime.InteropServices;
using YangiHayotAPI.Data;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly DataContext _dataContext;
        public OrderDetailService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Create(int OrderId, decimal Price, int ProductId)
        {
            OrderDetail orderDetail = new OrderDetail()
            {
                OrderId = OrderId,
                Price = Price,
                ProductId = ProductId
            };
            return orderDetail.Id;
        }

        public List<OrderDetail> Index()
        {
            return _dataContext.OrderDetails.ToList();
        }

        public OrderDetail Show(int Id)
        {
            var orderDetail = _dataContext.OrderDetails.FirstOrDefault(o => o.Id == Id);
            return orderDetail;
        }

        public string Update(int Id, int OrderId, decimal Price, int ProductId)
        {
            var orderDetail = _dataContext.OrderDetails.FirstOrDefault(o => o.Id == Id);
            if (orderDetail == null)
            {
                return "Not Found!";
            } 
            orderDetail.Price = Price;  
            orderDetail.ProductId = ProductId;  
            orderDetail.OrderId = OrderId;  
            _dataContext.SaveChanges();
            return "Updated!";
        }

        public void Delete(int Id) 
        {
            var orderDetail = _dataContext.Users.FirstOrDefault(o => o.Id == Id);
            if (orderDetail is not null)
            {
                _dataContext.Users.Remove(orderDetail);
                _dataContext.SaveChanges();
            }
        }
    }
}
