using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.Repositoris;

namespace MyWebApi.Business.Services;

public class UserServices : IUserServices
{
    public readonly IUsersRepository _usersRepository;

    public UserServices(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public List<UserDto> GetUsers()
    {
        return _usersRepository.GetUser();
    }

    public UserDto GetUserById(Guid id)
    {
        return _usersRepository.GetUserById(id);
    }
}