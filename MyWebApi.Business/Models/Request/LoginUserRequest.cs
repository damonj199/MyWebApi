﻿namespace MyWebApi.Business.Models.Request;

public class LoginUserRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
