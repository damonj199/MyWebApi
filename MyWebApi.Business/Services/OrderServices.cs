using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

namespace MyWebApi.Business.Services;

public class OrderServices : IOrderServices
{
    private readonly IOrdersRepository _ordersRepository;

    public OrderServices(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public List<OrdersDto> GetOrders() => _ordersRepository.GetOrders();

    public OrdersDto GetOrderById(Guid id) => _ordersRepository.GetOrderById(id);
}