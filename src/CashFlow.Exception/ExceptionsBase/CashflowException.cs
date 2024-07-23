namespace CashFlow.Exception.ExceptionsBase;
public abstract class CashflowException : SystemException
{
    protected CashflowException(string message) : base(message)
    {
        
    }
}
