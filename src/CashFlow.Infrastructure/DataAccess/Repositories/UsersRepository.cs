using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserDeleteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public UsersRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    async Task<User?> IUserReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
    }

    async Task<User?> IUserUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        
        if(result is null)
        {
            return false;
        }

        _dbContext.Users.Remove(result);

        return true;
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}
