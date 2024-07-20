using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUsersRepository
{
    public void Add(User user)
    {
        var dbContext = new CashFlowDbContext();

        dbContext.Users.Add(user);
        dbContext.SaveChanges();
    }
}
