using MyWebApi.Core.Dtos;
namespace MyWebApi.DataLayer.IRepository
{
    public interface IUsersRepository
    {
        List<UserDto> GetUsers();
        UserDto GetUserById(Guid id);
        UserDto GetUserEmail(string email);
        Guid AddUser(UserDto user);
        void DeleteUserById(UserDto user);
    }
}