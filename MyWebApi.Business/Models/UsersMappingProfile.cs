using AutoMapper;
using MyWebApi.Business.Models.Request;
using MyWebApi.Business.Models.Responses;
using MyWebApi.Core.Dtos;

namespace MyWebApi.Business.Models;

public class UsersMappingProfile : Profile
{
    public UsersMappingProfile()
    {
        CreateMap<CreateUserRequest, UserDto>();
        CreateMap<UserDto, User>();
    }
}
