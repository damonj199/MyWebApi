namespace MyWebApi.Business.Models.Request;

public class CreateUserRequest
{
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; } = 0;
}
