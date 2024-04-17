using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.Repositoris;

public class OrdersRepository : IOrdersRepository
{
    public OrdersRepository()
    {

    }

    public List<OrdersDto> GetOrders()
    {
        return new List<OrdersDto>();
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
