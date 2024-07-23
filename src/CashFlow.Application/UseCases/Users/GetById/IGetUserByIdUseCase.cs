using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Users.GetById;
public interface IGetUserByIdUseCase
{
    public Task<ResponseUserJson> Execute(long id);
}
