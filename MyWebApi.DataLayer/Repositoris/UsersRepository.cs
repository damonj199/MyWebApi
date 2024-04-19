using MyWebApi.Core.Dtos;

namespace MyWebApi.DataLayer.Repositoris;

public class UsersRepository : BaseRepository, IUsersRepository
{
    public UsersRepository(HotDogsContext context) : base(context)
    {
    }

    public List<UserDto> GetUser()
    {
        return _ctx.Users.ToList();
    }

    public UserDto GetUserById(Guid id)
    {
        return new()
        {
            Id = id,
            UserName = "Ivan",
            Password = "12345",
            Age = 21,
            Email = "Inanov12@mail.ru"
        };
    }

    //public UserDto DeleteUserById(Guid id)
    //{
    //    return _ctx.Users.FirstOrDefault();
    //}
}