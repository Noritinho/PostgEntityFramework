using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        // To do validations

        return new ResponseRegisteredUserJson();
    }
}
