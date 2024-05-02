using MyWebApi.Business.Models.Request;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.IServices;

public interface IOrderServices
{
    OrderDto GetOrderById(Guid id);
    List<OrderDto> GetOrders();
    void DeleteOrderyId(Guid id);
    Guid CreateOrder(CreateOrderRequest request);
    Guid UpdateOrder(UpdateOrderRequest request);
}