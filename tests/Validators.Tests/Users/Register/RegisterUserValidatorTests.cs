using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Users.Register;
public class RegisterUserValidatorTests
{
    [Fact]
    public void Success()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Error_Username_Empty()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.UserName = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.USERNAME_REQUIRED));
    }

    [Fact]
    public void Error_Email_Empty()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_REQUIRED));
    }

    [Fact]
    public void Error_Password_Empty()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PASSWORD_REQUIRED));
    }

    [Fact]
    public void Error_User_Type_Invalid()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Type = (UserType)4;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TYPE_INVALID));
    }
}
