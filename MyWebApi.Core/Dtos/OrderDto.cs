namespace MyWebApi.Core.Dtos;

public class OrderDto: IdContainer
{
    public string Name { get; set; } = string.Empty;

    public string TypeName { get; set; } = string.Empty;

    public int Price { get; set; } = 0;

    public UserDto? User { get; set; }

    public List<ProductDto>? Products { get; set; } = [];

}
