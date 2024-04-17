using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.Services;

public interface IOrderServices
{
    OrdersDto GetOrderById(Guid id);
    List<OrdersDto> GetOrders();
}