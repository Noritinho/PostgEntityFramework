using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterUserUseCase(
        IUserWriteOnlyRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task <ResponseRegisteredUserJson> Execute(RequestUserJson request)
    {
        Validate(request);

        var entity = _mapper.Map<User>(request);

        await _repository.Add(entity);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredUserJson>(entity);
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();
        var result = validator.Validate(request);

        if(!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
