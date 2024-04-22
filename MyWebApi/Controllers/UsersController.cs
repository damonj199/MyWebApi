using Microsoft.AspNetCore.Mvc;
using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Controllers;

[ApiController]
[Route("User")]
public class UsersController : Controller
{
    public readonly IUserServices _userServices;
    public UsersController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet("/api/getAllUsers")]
    public ActionResult<List<UserDto>> GetAllUsers()
    {
        return Ok(_userServices.GetUsers());
    }

    [HttpGet("/api/userById")]
    public ActionResult<UserDto> GetUserById(Guid guid)
    {
        return Ok(_userServices.GetUserById(guid));
    }
}
