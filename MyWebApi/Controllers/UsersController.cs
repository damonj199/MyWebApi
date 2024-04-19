using Microsoft.AspNetCore.Mvc;
using MyWebApi.Business.Services;
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

    [HttpGet("GetAllUsers")]
    public List<UserDto> GetAllUsers()
    {
        return _userServices.GetUsers();
    }

    [HttpGet("UserById")]
    public UserDto GetUserById(Guid guid)
    {
        return _userServices.GetUserById(guid);
    }

    [HttpGet("Test")]
    public int[] GetTest()
    {
        return [1, 2, 3, 4];
    }
}
