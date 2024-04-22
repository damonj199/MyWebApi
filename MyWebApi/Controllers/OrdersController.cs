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
    public ActionResult<OrdersDto> GetOrderById(Guid id)
    {
        if (id == Guid.Empty)
            return NotFound($"Заказа с id {id} не существует!");

        return Ok(_orderServices.GetOrderById(Guid.NewGuid()));
    }

    [HttpPost]
    public ActionResult<Guid> CreateOrder(object order)
    {
        return Guid.NewGuid();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrderById(Guid guid)
    {
        _orderServices.DeleteOrderyId(guid);
        return NoContent();
    }
}
