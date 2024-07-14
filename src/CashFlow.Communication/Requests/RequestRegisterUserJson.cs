using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;
public class RequestRegisterUserJson
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserType Type { get; set; }
}
