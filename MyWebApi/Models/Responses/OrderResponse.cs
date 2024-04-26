namespace MyWebApi.Api.Models.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TypeName { get; set; }
    public int Price { get; set; }
}
