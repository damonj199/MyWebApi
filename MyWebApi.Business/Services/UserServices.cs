using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MyWebApi.Business.IServices;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Core.Dtos;
using MyWebApi.Core.Exceptions;
using MyWebApi.DataLayer.IRepository;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWebApi.Business.Services;

public class UserServices : IUserServices
{
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger _logger = Log.ForContext<UserServices>();
    private readonly IMapper _mapper;
    //private const string _pepper = "pepper";
    //private const int _iteration = 7;

    public UserServices(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public AuthenticatedResponse LoginUser(LoginUserRequest loginUser)
    {
        _logger.Information($"Проверяем есть ли пользователь с таким {loginUser.Email}");

        var user = _usersRepository.GetUserEmail(loginUser.Email);

        if (user == null)
        {
            throw new Exception("проверьте введеный email");
        }

        _logger.Information($"Проверяем пароль на соотвествие {loginUser.Email}");
        if (!PasswodrHasher.Verify(loginUser.Password, user.Password))
        {
            throw new Exception("Не верные данные, попробуйте еще раз");
        }

        Claim[] claims = [new("userId", user.Id.ToString())];

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyWebApiSecretKeyMyWebApiSecretKeyMyWebApiSecretKey"));

        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: "ProjectMyWebApi",
            audience: "UI",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signinCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        _logger.Information($"{user.UserName} получает токен.");

        return new AuthenticatedResponse { Token = token };
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

        var hashedPassword = PasswodrHasher.Generete(request.Password);
        request.Password = hashedPassword;

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