using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Users.GetAll;
public interface IGetAllUserUseCase
{
    public Task<ResponseUserJson> Execute();
}
