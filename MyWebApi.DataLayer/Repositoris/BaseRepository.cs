namespace MyWebApi.DataLayer.Repositoris;

public class BaseRepository
{
    protected readonly HotDogsContext _ctx;

    public BaseRepository(HotDogsContext context)
    {
        _ctx = context;
    }
}
