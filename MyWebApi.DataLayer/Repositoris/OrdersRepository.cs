using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.Repositoris;

public class OrdersRepository : BaseRepository, IOrdersRepository
{
    public OrdersRepository(HotDogsContext context) : base(context)
    {

    }

    public List<OrdersDto> GetOrders()
    {
        return _ctx.Orders.ToList();
    }

    public OrdersDto GetOrderById(Guid id)
    {
        return new()
        {
            Id = id,
            Name = "Car",
            TypeName = "Cabriolet",
            Prace = 1200000
        };
    }
}
