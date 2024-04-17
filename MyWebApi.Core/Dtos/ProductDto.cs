namespace MyWebApi.Core.Dtos;
public class ProductDto : IdContainer
{
    public string ProductName { get; set; } = string.Empty;

    public string ProductType { get; set; } = string.Empty;

    public int Amount { get; set; } = 0;

    public decimal Price { get; set; } = 0;

    public OrdersDto? Orders { get; set; }
}
