using Microsoft.AspNetCore.Mvc;
using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using Serilog;

namespace MyWebApi.Controllers;

[ApiController]
[Route("User")]
public class UsersController : Controller
{
    private readonly IUserServices _userServices;
    private readonly Serilog.ILogger _logger = Log.ForContext<UsersController>();

    public UsersController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet("/api/allUsers")]
    public ActionResult<List<UserDto>> GetAllUsers()
    {
        return Ok(_userServices.GetUsers());
    }

    [HttpGet("/api/userById")]
    public ActionResult<UserDto> GetUserById(Guid guid)
    {
        return Ok(_userServices.GetUserById(guid));
    }

    [HttpPut("{id}")]
    public ActionResult<UserDto> UpdatetUserById([FromRoute] Guid? guid, [FromBody] object request)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(Guid guid)
    {
        return NoContent();
    }
}
