using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Update;
public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserUpdateOnlyRepository _repository;
    public UpdateUserUseCase(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task Execute(long id, RequestUserJson request)
    {
        Validate(request);

        var user = await _repository.GetById(id);

        if (user == null)
        {
            throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
        }

        _mapper.Map(request, user);
        _repository.Update(user);

        await _unitOfWork.Commit();
    }

    public void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
