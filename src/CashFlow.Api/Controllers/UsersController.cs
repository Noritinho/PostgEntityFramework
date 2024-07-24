using CashFlow.Application.UseCases.Users.Delete;
using CashFlow.Application.UseCases.Users.GetAll;
using CashFlow.Application.UseCases.Users.GetById;
using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task <IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseUsersJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers([FromServices] IGetAllUserUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Users.Count != 0)
            return Ok(response);

        return NoContent();

    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetUserByIdUseCase useCase,
    [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);

    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteUserUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
