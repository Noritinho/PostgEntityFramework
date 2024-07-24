using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users;
public interface IUserDeleteOnlyRepository
{
    public Task<bool> Delete(long id);
}
