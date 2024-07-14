using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterUserJson request)
    {
        var useCase = new RegisterUserUseCase();
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
