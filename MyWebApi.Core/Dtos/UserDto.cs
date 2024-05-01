using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace MyWebApi.Core.Dtos;

public class UserDto: IdContainer
{

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Age { get; set; } = 0;

    public List<OrderDto> Orders { get; set; } = [];

}
