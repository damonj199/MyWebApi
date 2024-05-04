using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;
using Serilog;

namespace MyWebApi.DataLayer.Repositoris;

public class UsersRepository : BaseRepository, IUsersRepository
{
    private readonly ILogger _logger = Log.ForContext<UsersRepository>();
    public UsersRepository(HotDogsContext context) : base(context)
    {
    }

    public List<UserDto> GetUsers()
    {
        return _ctx.Users.ToList();
    }

    public UserDto GetUserById(Guid id)
    {
        _logger.Information($"Идем в базу смотреть Клиента по id {id}");
        return _ctx.Users.FirstOrDefault(x => x.Id == id);
    }
    public Guid AddUser(UserDto user)
    {
        _ctx.Users.Add(user);
        _ctx.SaveChanges();
        return user.Id;
    }

    public void DeleteUserById(UserDto user)
    {
        _ctx.Users.Remove(user);
        _ctx.SaveChanges();

        _logger.Information($"Клиента больше не существует");
    }
}