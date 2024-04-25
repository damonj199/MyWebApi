using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.IRepository;

public interface IOrdersRepository
{
    OrderDto CreateOrder(Guid id, string name, string typename, int prece);
    OrderDto GetOrderById(Guid id);
    List<OrderDto> GetOrders();
}