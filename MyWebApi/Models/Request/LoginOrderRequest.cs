﻿namespace MyWebApi.Api.Models.Request;

public class LoginOrderRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}