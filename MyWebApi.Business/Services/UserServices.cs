using AutoMapper;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Core.Dtos;
using MyWebApi.Core.Exceptions;
using MyWebApi.DataLayer.IRepository;
using Serilog;

namespace MyWebApi.Business.Services;

public class UserServices : IUserServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger _logger = Log.ForContext<UserServices>();
    private readonly IMapper _mapper;
    private readonly IPasswodrHasher _passwordHasher;
    private readonly JwtToken _jwtToken;
    private const string _pepper = "pepper";
    private const int _iteration = 7;

    public UserServices(IUsersRepository usersRepository, IMapper mapper, IPasswodrHasher passwodrHasher, JwtToken jwtToken)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _passwordHasher = passwodrHasher;
        _jwtToken = jwtToken;
    }

    public AuthenticatedResponse LoginUser(LoginUserRequest loginUser)
    {
        _logger.Information($"Проверяем есть ли пользователь с таким {loginUser.Email}");

        var user = _usersRepository.GetUserEmail(loginUser.Email);

        if (user == null)
        {
            throw new Exception("проверьте введеный email");
        }

        var result = _passwordHasher.Verify(loginUser.Password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Пароль не верный");
        }

        var token = _jwtToken.GenerateToken(user);

        return new AuthenticatedResponse { Token = token};
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
        if (request.Age < 16 || request.Age > 100)
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