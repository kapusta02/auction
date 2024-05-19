using Auction.Enums;

namespace Auction.Configurations;

public class ExceptionsExtension : Exception
{
    public ExceptionTypes ExceptionType { get; set; }

    public ExceptionsExtension(ExceptionTypes exceptionType, string message) : base(message)
    {
        ExceptionType = exceptionType;
    }
}