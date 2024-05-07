using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
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

    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> Login([FromBody] LoginUserRequest order)
    {
        if (order is null)
        {
            return BadRequest("Invalid client request");
        }
        if (order.UserName == "qwe123" && order.Password == "123qwe")
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

    [HttpGet]
    public ActionResult<List<OrderDto>> GetOrders()
    {
        _logger.Information($"Получаем списов всех заказов");
        return Ok(_orderServices.GetOrders());
    }

    [HttpGet("oredrById/{id}")]
    public ActionResult<OrderResponse> GetOrderById(Guid id)
    {
        _logger.Information($"Получаем заказ по id {id}");
        return Ok(_orderServices.GetOrderById(id));
    }

    [HttpPost]
    public ActionResult<Guid> CreateOrder([FromBody] CreateOrderRequest request)
    {
        _logger.Information($"Идем в сервис валидировать данный и создавать заказ");
        return Ok(_orderServices.CreateOrder(request));
    }

    [HttpPut("{id}")]
    public ActionResult<Guid> UpdateOrder([FromBody] UpdateOrderRequest request)
    {
        _logger.Information("Для обновления дергаем сервис");

        return Ok(_orderServices.UpdateOrder(request));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrderById(Guid id)
    {
        _logger.Information($"Удаляем заказ по id {id}");
        _orderServices.DeleteOrderyId(id);
        return NoContent();
    }
}
