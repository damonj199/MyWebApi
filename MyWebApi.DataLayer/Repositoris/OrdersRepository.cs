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
            Name = "Кость",
            TypeName = "Игрушка для собак",
            Prace = 500
        };
    }
}
