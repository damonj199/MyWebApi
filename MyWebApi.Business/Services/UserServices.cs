using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;
using Serilog;

namespace MyWebApi.Business.Services;

public class UserServices : IUserServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger _logger = Log.ForContext<UserServices>();

    public UserServices(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public List<UserDto> GetUsers() => _usersRepository.GetUser();

    public UserDto GetUserById(Guid id) => _usersRepository.GetUserById(id);

}