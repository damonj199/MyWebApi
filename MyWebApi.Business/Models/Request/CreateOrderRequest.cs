namespace MyWebApi.Business.Models.Request;

public class CreateOrderRequest
{
    public string? UserName { get; set; }
    public DateTime Data { get; set; }
    public int Summa { get; set; }
}
