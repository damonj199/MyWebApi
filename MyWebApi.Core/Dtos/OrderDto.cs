namespace MyWebApi.Core.Dtos;

public class OrderDto: IdContainer
{
    public string UserName { get; set; } = string.Empty;

    public DateTime Data { get; set; }

    public int Summa { get; set; } = 0;

    public UserDto? User { get; set; }

    public List<ProductDto>? Products { get; set; } = [];

}
