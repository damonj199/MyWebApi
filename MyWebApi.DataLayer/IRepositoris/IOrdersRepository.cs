using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.IRepository;

public interface IOrdersRepository
{
    void CreateOrder();
    OrdersDto GetOrderById(Guid id);
    List<OrdersDto> GetOrders();
}