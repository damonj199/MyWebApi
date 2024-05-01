namespace MyWebApi.Api.Models.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public DateTime? Data { get; set; }
    public int Summa { get; set; }
}
