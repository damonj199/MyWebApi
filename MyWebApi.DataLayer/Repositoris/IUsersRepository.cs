using MyWebApi.Core.Dtos;
namespace MyWebApi.DataLayer.Repositoris
{
    public interface IUsersRepository
    {
        List<UserDto> GetUser();
        UserDto GetUserById(Guid id);
        //UserDto DeleteUserById(Guid id);
    }
}