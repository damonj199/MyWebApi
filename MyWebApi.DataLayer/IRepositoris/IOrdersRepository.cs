using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.IRepository;

public interface IOrdersRepository
{
    OrdersDto GetOrderById(Guid id);
    List<OrdersDto> GetOrders();
}