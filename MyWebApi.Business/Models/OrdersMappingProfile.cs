using AutoMapper;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.Models;

public class OrdersMappingProfile : Profile
{
    public OrdersMappingProfile()
    {
        CreateMap<CreateOrderRequest, OrderDto>();
        CreateMap<OrderDto, OrderResponse>();
    }
}
