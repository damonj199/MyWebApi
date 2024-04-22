﻿using MyWebApi.Business.IServices;
using MyWebApi.Core.Dtos;
using MyWebApi.DataLayer.IRepository;

namespace MyWebApi.Business.Services;

public class UserServices : IUserServices
{
    public readonly IUsersRepository _usersRepository;

    public UserServices(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }0

    public List<UserDto> GetUsers() => _usersRepository.GetUser();

    public UserDto GetUserById(Guid id) => _usersRepository.GetUserById(id);

}