using MyWebApi.Core.Dtos;
namespace MyWebApi.DataLayer.IRepository
{
    public interface IUsersRepository
    {
        List<UserDto> GetUser();
        UserDto GetUserById(Guid id);
        //UserDto DeleteUserById(Guid id);
    }
}