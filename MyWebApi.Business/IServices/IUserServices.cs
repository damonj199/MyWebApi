using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.IServices;

public interface IUserServices
{
    UserDto GetUserById(Guid id);
    List<UserDto> GetUsers();
}