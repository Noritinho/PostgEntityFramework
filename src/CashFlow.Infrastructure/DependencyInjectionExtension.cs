using CashFlow.Domain.Repositories.Users;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
    }

    public static void AddDbConnection(this IServiceCollection services, string? v)
    {
        services.AddDbContext<CashFlowDbContext>();
    }
}
