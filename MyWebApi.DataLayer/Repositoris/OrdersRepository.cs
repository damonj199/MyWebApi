using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

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

    public OrdersDto GetOrderById(Guid id) => _ctx.Orders.FirstOrDefault(x => x.Id == id);

    //public OrdersDto DeleteOrderById(Guid id)
    //{
    //    return _ctx.Orders.Remove();
    //}
}
