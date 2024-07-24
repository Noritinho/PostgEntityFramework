using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;

namespace CashFlow.Application.UseCases.Users.GetAll;
public class GetAllUserUseCase : IGetAllUserUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllUserUseCase(IUserReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseUsersJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseUsersJson
        {
            Users = _mapper.Map<List<ResponseShortUserJson>>(result)
        };
    }
}
