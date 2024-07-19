using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.UserName).NotEmpty().WithMessage(ResourceErrorMessages.USERNAME_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_REQUIRED);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceErrorMessages.PASSWORD_REQUIRED);
        RuleFor(user => user.Type).IsInEnum().WithMessage(ResourceErrorMessages.TYPE_INVALID);
    }
}
