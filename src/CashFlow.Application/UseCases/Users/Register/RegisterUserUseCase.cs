﻿using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUsersRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterUserUseCase(IUsersRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var entity = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = request.Password,
            UserType = (Domain.Enums.UserType)request.UserType
        };

        _repository.Add(entity);
        _unitOfWork.Commit();

        return new ResponseRegisteredUserJson();
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if(!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
