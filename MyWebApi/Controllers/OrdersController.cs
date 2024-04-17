using Microsoft.AspNetCore.Mvc;
using MyWebApi.Business.Services;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Controllers;

[ApiController]
[Route("Order")]
public class OrdersController : Controller
{
    private readonly IOrderServices _orderServices;
    public OrdersController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpGet("Oredr1")]
    public List<OrdersDto> GetOrser()
    {
        return _orderServices.GetOrders();
    }

    [HttpGet("OredrById")]
    public OrdersDto GetOrderById(Guid guid)
    {
        return _orderServices.GetOrderById(Guid.NewGuid());
    }

    [HttpGet("Test")]
    public int[] GetTest()
    {
        return [1, 2, 3, 4];
    }
}
