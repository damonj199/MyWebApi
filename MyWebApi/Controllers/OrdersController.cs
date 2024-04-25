using Microsoft.AspNetCore.Mvc;
using MyWebApi.Api.Models.Request;
using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using Serilog;

namespace MyWebApi.Controllers;

[ApiController]
[Route("/api/o rder")]
public class OrdersController : Controller
{
    private readonly IOrderServices _orderServices;
    private readonly Serilog.ILogger _logger = Log.ForContext<OrdersController>();
    public OrdersController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpGet("/api/oredrs")]
    public ActionResult<List<OrderDto>> GetOrser()
    {
        _logger.Information($"Получаем списов всех заказов");
        return Ok(_orderServices.GetOrders());
    }

    [HttpGet("/api/oredrById/")]
    public ActionResult<OrderDto> GetOrderById(Guid id)
    {
        if (id == Guid.Empty)
            return NotFound($"Заказа с id {id} не существует!");

        _logger.Information($"Получаем заказ по id {id}");
        return Ok(_orderServices.GetOrderById(Guid.NewGuid()));
    }

    [HttpPost]
    public ActionResult<Guid> CreateOrder([FromBody] CreateOrderRequest request)
    {
        _logger.Information($"{request.Name} {request.Prece}");
        var id = _orderServices.CreateOrder(new()
        {
            Name = request.Name,
            TypeName = request.TypeName,
            Prace = request.Prece
        });
        _logger.Information($"Сoздаем новый заказ");
        return Ok(id);
    }

    [HttpDelete]
    public IActionResult DeleteOrderById(Guid id)
    {
        _logger.Information($"Удаляем заказ по id {id}");
        _orderServices.DeleteOrderyId(id);
        return NoContent();
    }
}
