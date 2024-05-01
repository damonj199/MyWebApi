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
        _logger.Information("Идем в базку за всеми заказами!");
        return _ctx.Orders.ToList();
    }

    //public void DeleteOrderById(Guid id)
    //{
    //    _ctx.Orders.Remove(id);
    //    _ctx.SaveChanges();

    //}

    public OrderDto CreateOrder(Guid id, string name, string typename, int price)
    {
        var order = new OrderDto
        {
            Id = id,
            Name = name,
            TypeName = typename,
            Price = price
        };

        _logger.Information("Добавляем заказ в базу");

        _ctx.Add(order);
        _ctx.SaveChanges();

        return order;
    }

    public Guid UpdateOrder(OrderDto order)
    {
        _logger.Information("Идем в базу и обновляем данные по заказу");

        _ctx.Orders.Update(order);
        _ctx.SaveChanges();

        return order.Id;
    }
    public OrderDto GetOrderById(Guid id) => _ctx.Orders.FirstOrDefault(o => o.Id == id);
}
