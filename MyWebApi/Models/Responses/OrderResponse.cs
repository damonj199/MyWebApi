namespace MyWebApi.Api.Models.Responses;

public class OrderResponse
{
    public Guid id { get; set; };
    public string Name { get; set; }
    public string TypeName { get; set; }
    public int Prece { get; set; }
}
