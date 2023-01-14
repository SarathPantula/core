namespace core.Exceptions;

/// <summary>
/// Generic Exception
/// </summary>
public class GenericException : Exception, IException
{
    /// <summary>
    /// 
    /// </summary>
    public GenericException(int errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
    /// <summary>
    /// 
    /// </summary>
    public GenericException(int errorCode, string message, Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// ErrorCode
    /// </summary>
    public int ErrorCode { get; set; }
}