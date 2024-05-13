namespace MyWebApi.Core.Dtos;
public class ProductDto : IdContainer
{
    public string ProductName { get; set; } = string.Empty;

    public string ProductType { get; set; } = string.Empty;

    public decimal Price { get; set; } = 0;

    public int Amount { get; set; } = 0;

    public OrderDto? Orders { get; set; }
}
