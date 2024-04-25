using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;
using Serilog;

namespace MyWebApi.DataLayer.Repositoris;

public class OrdersRepository : BaseRepository, IOrdersRepository
{
    private readonly ILogger _logger = Log.ForContext<OrdersRepository>();
    public OrdersRepository(HotDogsContext context) : base(context)
    {
    }

    public List<OrderDto> GetOrders()
    {
        return _ctx.Orders.ToList();
    }

    //public void DeleteOrderById(Guid id)
    //{
    //    _ctx.Orders.Remove(id);
    //    _ctx.SaveChanges();

    //}

    public OrderDto CreateOrder(Guid id, string name, string typename, int prece)
    {
        var order = new OrderDto
        {
            Id = id,
            Name = name,
            TypeName = typename,
            Prace = prece
        };

        _logger.Information("Добавляем заказ в базу");
        _ctx.Add(order);
        _ctx.SaveChanges();
        return order;
    }

    public OrderDto GetOrderById(Guid id)
    {
        throw new NotImplementedException();
    }
}
