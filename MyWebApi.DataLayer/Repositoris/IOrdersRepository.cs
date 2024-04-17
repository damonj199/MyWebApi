using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.Repositoris;

public interface IOrdersRepository
{
    OrdersDto GetOrderById(Guid id);
    List<OrdersDto> GetOrders();
}