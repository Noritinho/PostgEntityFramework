using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Register;
internal class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.UserName).NotEmpty().WithMessage("The UserName is required");
        RuleFor(user => user.Email).NotEmpty().WithMessage("The Email is required");
        RuleFor(user => user.Password).NotEmpty().WithMessage("The Password is required");
        RuleFor(user => user.Type).IsInEnum().WithMessage("The Type is not valid");
    }
}
