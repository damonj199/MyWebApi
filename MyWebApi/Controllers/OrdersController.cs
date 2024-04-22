using Microsoft.AspNetCore.Mvc;
using MyWebApi.Business.IServices;
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

    [HttpGet("/api/oredrs")]
    public ActionResult<List<OrdersDto>> GetOrser()
    {
        return Ok(_orderServices.GetOrders());
    }

    [HttpGet("/api/oredrById/")]
    public ActionResult<OrdersDto> GetOrderById(Guid guid)
    {
        return Ok(_orderServices.GetOrderById(Guid.NewGuid()));
    }
}
