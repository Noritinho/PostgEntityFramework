using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users;
public interface IUsersRepository
{
    public Task Add(User user);
}
