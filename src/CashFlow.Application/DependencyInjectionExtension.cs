using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Users.Delete;
using CashFlow.Application.UseCases.Users.GetAll;
using CashFlow.Application.UseCases.Users.GetById;
using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Application.UseCases.Users.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        services.AddScoped<IGetAllUserUseCase, GetAllUserUseCase>();
        services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
    }
}
