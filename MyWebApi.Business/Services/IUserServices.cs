using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.Services
{
    public interface IUserServices
    {
        UserDto GetUserById(Guid id);
        List<UserDto> GetUsers();
    }
}