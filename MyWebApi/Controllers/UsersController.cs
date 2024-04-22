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
    public List<UserDto> GetAllUsers()
    {
        return _userServices.GetUsers();
    }

    [HttpGet("/api/userById")]
    public UserDto GetUserById(Guid guid)
    {
        return _userServices.GetUserById(guid);
    }
}
