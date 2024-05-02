using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.IRepository;

public interface IOrdersRepository
{
    Guid CreateOrder(OrderDto order);
    OrderDto GetOrderById(Guid id);
    List<OrderDto> GetOrders();
    Guid UpdateOrder(OrderDto order);
}