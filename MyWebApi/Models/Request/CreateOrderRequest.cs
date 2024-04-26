namespace MyWebApi.Api.Models.Request;

public class CreateOrderRequest
{
    public string Name { get; set; }
    public string TypeName { get; set; }
    public int Price { get; set; }
}
