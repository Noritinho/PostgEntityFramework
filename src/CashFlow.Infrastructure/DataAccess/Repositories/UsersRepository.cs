using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUsersRepository
{
    private readonly CashFlowDbContext _dbContext;
    public UsersRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(User user)
    {
        _dbContext.Users.Add(user);
    }
}
