using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.Repositoris;

namespace MyWebApi.Business.Services;

public class OrderServices : IOrderServices
{
    private readonly IOrdersRepository _ordersRepository;
    public OrderServices(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public List<OrdersDto> GetOrders()
    {
        return _ordersRepository.GetOrders();
    }

    public OrdersDto GetOrderById(Guid id)
    {
        return _ordersRepository.GetOrderById(id);
    }
}
