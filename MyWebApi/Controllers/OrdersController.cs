using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWebApi.Api.Models.Request;
using MyWebApi.Api.Models.Responses;
using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebApi.Controllers;

//[Authorize]
[ApiController]
[Route("/api/orders")]
public class OrdersController : Controller
{
    private readonly IOrderServices _orderServices;
    private readonly Serilog.ILogger _logger = Log.ForContext<OrdersController>();
    public OrdersController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpGet]
    public ActionResult<List<OrderDto>> GetOrders()
    {
        _logger.Information($"Получаем списов всех заказов");
        return Ok(_orderServices.GetOrders());
    }

    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> Login([FromBody] LoginOrderRequest order)
    {
        if (order is null)
        {
            return BadRequest("Invalid client request");
        }
        if (order.UserName == "johndoe" && order.Password == "def@123")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myWebApi_superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "MyWebApi",
                audience: "UI",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString });
        }
        return Unauthorized();
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
            Price = order.Price
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
            Price = request.Price
        });
        _logger.Information($"Сoздаем новый заказ");
        return Ok(id);
    }

    [HttpPut("{id}")]
    public ActionResult<Guid> UpdateOrder(Guid id, string name, string typeName, int price)
    {
        _logger.Information("Для обновления дергаем сервис");
        var order = _orderServices.GetOrderById(id);
        order.Name = name;
        order.TypeName = typeName;
        order.Price = price;

        return Ok(_orderServices.UpdateOrder(order));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrderById(Guid id)
    {
        _logger.Information($"Удаляем заказ по id {id}");
        _orderServices.DeleteOrderyId(id);
        return NoContent();
    }
}
