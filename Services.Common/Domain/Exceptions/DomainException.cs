namespace Services.Common.Domain.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message) 
        : base(message) {}

}
