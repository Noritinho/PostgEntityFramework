using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.GetById;
public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetUserByIdUseCase(IUserReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseUserJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.USER_NOT_FOUND);
        }
        return _mapper.Map<ResponseUserJson>(result);
    }
}
