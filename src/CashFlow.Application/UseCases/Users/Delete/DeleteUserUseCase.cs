using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Delete;
public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUserDeleteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUserUseCase(
        IUserDeleteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }
}
