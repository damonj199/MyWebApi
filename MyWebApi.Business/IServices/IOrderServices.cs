using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.IServices;

public interface IOrderServices
{
    OrdersDto GetOrderById(Guid id);
    List<OrdersDto> GetOrders();
    void DeleteOrderyId(Guid id);
    void CreateOrder(object order);
}