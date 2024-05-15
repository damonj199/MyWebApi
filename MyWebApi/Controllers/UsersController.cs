using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Core.Dtos;
using Serilog;

namespace MyWebApi.Controllers;

[ApiController]
[Route("/api/user")]
public class UsersController : Controller
{
    private readonly IUserServices _userServices;
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersController>();

    public UsersController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    //[Authorize]
    [HttpGet("allUsers")]
    public ActionResult<List<UserDto>> GetAllUsers()
    {
        _logger.Information("Делаем запрос спикска всей клиентов");

        return Ok(_userServices.GetUsers());
    }

    [HttpGet("userById/{id}")]
    public ActionResult<Guid> GetUserById(Guid id)
    {
        return Ok(_userServices.GetUserById(id));
    }

    [HttpPost]
    public ActionResult<Guid> AddUser([FromBody] CreateUserRequest request)
    {
        _logger.Information("Дергаем метод сервиса по добавлению клиента");
        return Ok(_userServices.AddUser(request));
    }

    [HttpPut("{id}")]
    public ActionResult<UserDto> UpdatetUserById([FromBody] UpdateUserRequest request)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(Guid guid)
    {
        _userServices.DeleteUserById(guid);
        return NoContent();
    }

    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> Login([FromBody] LoginUserRequest loginUser)
    {
        var authenticated = _userServices.LoginUser(loginUser);

        return Ok(authenticated);
    }
}
