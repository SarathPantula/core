namespace core.Exceptions;

/// <summary>
/// Validator Exception
/// </summary>
public class ValidatorException : GenericException
{
    /// <summary>
    /// 
    /// </summary>
    public ValidatorException(int errorCode, string message) : base(errorCode, message)
    {
    }
    /// <summary>
    /// 
    /// </summary>
    public ValidatorException(int errorCode, string message, Exception innerException) : base(errorCode, message, innerException)
    {
    }
}
