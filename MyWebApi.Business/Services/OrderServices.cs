using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;
using Serilog;

namespace MyWebApi.Business.Services;

public class OrderServices : IOrderServices
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly ILogger _logger = Log.ForContext<OrderServices>();
    public OrderServices(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public List<OrderDto> GetOrders() => _ordersRepository.GetOrders();

    public OrderDto GetOrderById(Guid id) => _ordersRepository.GetOrderById(id);

    public void DeleteOrderyId(Guid id)
    {
        var order = _ordersRepository.GetOrderById(id);
        if (order == null)
        {

        }
        //_ordersRepository.DeleteOrderById(order);
    }

    public OrderDto CreateOrder(OrderDto order)
    {
        _logger.Information("Пытвемся создать заказ через репозиторий!");
        _ordersRepository.CreateOrder(Guid.NewGuid(), order.Name, order.TypeName, order.Price);
        return order;
    }

    public Guid UpdateOrder(OrderDto order)
    {
        order.Id = Guid.NewGuid();
        return _ordersRepository.UpdateOrder(order);
    }
}