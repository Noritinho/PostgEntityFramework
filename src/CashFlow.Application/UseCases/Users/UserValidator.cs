﻿using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users;
public class UserValidator : AbstractValidator<RequestUserJson>
{
    public UserValidator()
    {
        RuleFor(user => user.UserName).NotEmpty().WithMessage(ResourceErrorMessages.USERNAME_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_REQUIRED);
        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceErrorMessages.PASSWORD_REQUIRED);
        RuleFor(user => user.UserType).IsInEnum().WithMessage(ResourceErrorMessages.TYPE_INVALID);
    }
}
