﻿using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;
public class RequestUserJson
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserType UserType { get; set; }
}
