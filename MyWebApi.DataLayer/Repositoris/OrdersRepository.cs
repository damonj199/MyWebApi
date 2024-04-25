using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

namespace MyWebApi.DataLayer.Repositoris;

public class OrdersRepository : BaseRepository, IOrdersRepository
{
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
        var Order = new OrderDto
        {
            Id = id,
            Name = name,
            TypeName = typename,
            Prace = prece
        };

        _ctx.Add(Order);
        _ctx.SaveChanges();
        return Order;
    }

    public OrderDto GetOrderById(Guid id)
    {
        throw new NotImplementedException();
    }
}
