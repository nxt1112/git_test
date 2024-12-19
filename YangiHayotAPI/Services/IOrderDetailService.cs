using System.Net;
using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public interface IOrderDetailService
    {
        public int Create(int OrderId, decimal Price, int ProductId);
        public List<OrderDetail> Index();
        public OrderDetail Show(int Id);
        public string Update(int Id, int OrderId, decimal Price, int ProductId);
        public void Delete(int Id); 
    }
}
