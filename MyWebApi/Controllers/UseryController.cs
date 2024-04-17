using Microsoft.AspNetCore.Mvc;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Controllers;

[ApiController]
[Route("User")]
public class UseryController : Controller
{
    private string _userName = "Vita";
    public UseryController()
    {
        
    }

    [HttpGet("UserName")]
    public string GetString()
    {
        return _userName;
    }

    [HttpGet("OredrById")]
    public OrdersDto GetOrderById(Guid guid)
    {
        return new();
    }
}
