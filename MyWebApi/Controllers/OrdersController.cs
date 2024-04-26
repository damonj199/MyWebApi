using Microsoft.AspNetCore.Mvc;
using MyWebApi.Api.Models.Request;
using MyWebApi.Api.Models.Responses;
using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using Serilog;

namespace MyWebApi.Controllers;

[ApiController]
[Route("/api/order")]
public class OrdersController : Controller
{
    private readonly IOrderServices _orderServices;
    private readonly Serilog.ILogger _logger = Log.ForContext<OrdersController>();
    public OrdersController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpGet("oredrs")]
    public ActionResult<List<OrderDto>> GetOrser()
    {
        _logger.Information($"Получаем списов всех заказов");
        return Ok(_orderServices.GetOrders());
    }

    [HttpGet("oredrById/")]
    public ActionResult<OrderDto> GetOrderById(Guid id)
    {
        if (id == Guid.Empty)
            return NotFound($"Заказа с id {id} не существует!");

        _logger.Information($"Получаем заказ по id {id}");

        var order = _orderServices.GetOrderById(id);
        OrderResponse response = new OrderResponse()
        {
            Id = order.Id,
            Name = order.Name,
            TypeName = order.TypeName,
            Price = order.Prace
        };
        return Ok(response);
    }

    [HttpPost]
    public ActionResult<Guid> CreateOrder([FromBody] CreateOrderRequest request)
    {
        _logger.Information($"{request.Name} {request.Price}");
        var id = _orderServices.CreateOrder(new()
        {
            Name = request.Name,
            TypeName = request.TypeName,
            Prace = request.Price
        });
        _logger.Information($"Сoздаем новый заказ");
        return Ok(id);
    }

    [HttpPut("{id}")]
    public ActionResult<Guid> UpdateOrder(Guid id, string name, string typeName, int price)
    {
        _logger.Information("Для обновления дергаем сервис");
        var order = _orderServices.GetOrderById(id);
        name = order.Name;
        typeName = order.TypeName;
        price = order.Prace;

        return Ok(_orderServices.UpdateOrder(order));
    }

    [HttpDelete]
    public IActionResult DeleteOrderById(Guid id)
    {
        _logger.Information($"Удаляем заказ по id {id}");
        _orderServices.DeleteOrderyId(id);
        return NoContent();
    }
}
