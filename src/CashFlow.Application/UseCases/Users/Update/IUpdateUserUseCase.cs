using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    public Task Execute(long id, RequestUserJson request);
}
