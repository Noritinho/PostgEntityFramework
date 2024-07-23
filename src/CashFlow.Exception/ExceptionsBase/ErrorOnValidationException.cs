﻿namespace CashFlow.Exception.ExceptionsBase;
public class ErrorOnValidationException : CashflowException
{
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        Errors = errorMessages;
    }
}
