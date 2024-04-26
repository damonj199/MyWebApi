using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.IServices;

public interface IOrderServices
{
    OrderDto GetOrderById(Guid id);
    List<OrderDto> GetOrders();
    void DeleteOrderyId(Guid id);
    OrderDto CreateOrder(OrderDto order);
    Guid UpdateOrder(OrderDto order);
}