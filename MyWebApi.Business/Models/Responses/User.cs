﻿namespace MyWebApi.Business.Models.Responses;

public class User
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public int Age { get; set; }
}