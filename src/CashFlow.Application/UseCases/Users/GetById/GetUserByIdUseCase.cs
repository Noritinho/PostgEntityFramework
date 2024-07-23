using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;

namespace CashFlow.Application.UseCases.Users.GetById;
public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IUsersRepository _repository;
    private readonly IMapper _mapper;
    public GetUserByIdUseCase(IUsersRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseUserJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        return _mapper.Map<ResponseUserJson>(result);
    }
}
