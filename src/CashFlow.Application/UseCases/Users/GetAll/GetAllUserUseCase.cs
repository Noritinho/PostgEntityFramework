using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;

namespace CashFlow.Application.UseCases.Users.GetAll;
public class GetAllUserUseCase : IGetAllUserUseCase
{
    private readonly IUsersRepository _repository;
    private readonly IMapper _mapper;
    public GetAllUserUseCase(IUsersRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseUserJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseUserJson
        {
            Users = _mapper.Map<List<ResponseShortUserJson>>(result)
        };
    }
}
