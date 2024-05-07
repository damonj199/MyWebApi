using AutoMapper;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;
using Serilog;
using MyWebApi.Core.Exceptions;

namespace MyWebApi.Business.Services;

public class UserServices : IUserServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger _logger = Log.ForContext<UserServices>();
    private readonly IMapper _mapper;

    public UserServices(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public List<UserDto> GetUsers()
    {
        return _usersRepository.GetUsers();
    }

    public UserDto GetUserById(Guid id)
    {
        return _usersRepository.GetUserById(id);
    }

    public Guid AddUser(CreateUserRequest request)
    {
        _logger.Information("Проверяем введенный возраст клиента");
        if(request.Age < 16 || request.Age > 100)
        {
            throw new ValidationException("Возраст указан не верно");
        }
        _logger.Information($"Добавляем клиента по имени {request.UserName}");

        UserDto user = _mapper.Map<UserDto>(request);

        return _usersRepository.AddUser(user);
    }

    public void DeleteUserById(Guid id)
    {
        var user = _usersRepository.GetUserById(id);

        if (user == null)
        {
            throw new Exception($"Не удалось найти клиента с id {id}");
        }
        _usersRepository.DeleteUserById(user);
    }
}