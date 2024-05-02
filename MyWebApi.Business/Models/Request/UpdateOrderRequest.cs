namespace MyWebApi.Business.Models.Request;

public class UpdateOrderRequest
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public DateTime Date { get; set; }
    public int Summa { get; set; }
}
