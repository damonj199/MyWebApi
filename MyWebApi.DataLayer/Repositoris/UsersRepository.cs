using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

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

    public UserDto GetUserById(Guid id) => _ctx.Users.FirstOrDefault(x => x.Id == id);


    //public UserDto DeleteUserById(Guid id)
    //{
    //    return _ctx.Users.FirstOrDefault();
    //}
}