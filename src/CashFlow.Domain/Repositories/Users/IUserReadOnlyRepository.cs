using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users;
public interface IUserReadOnlyRepository
{
    public Task<List<User>> GetAll();
    public Task<User?> GetById(long id);
}
