using YangiHayotAPI.Models;

namespace YangiHayotAPI.Services
{
    public interface IOrderService
    {
        List<Order> GetOrdersList();

        Order CreateNewOrder(decimal price, int userid);

        Order? GetOneOrder(int id);

        Order UpdateOrder(decimal price, Order order);

        void DeleteOrder(Order order);
    }
}
