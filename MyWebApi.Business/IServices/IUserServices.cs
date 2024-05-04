using MyWebApi.Business.Models.Request;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.IServices;

public interface IUserServices
{
    List<UserDto> GetUsers();
    UserDto GetUserById(Guid id);
    Guid AddUser(CreateUserRequest request);
    void DeleteUserById(Guid id);
}