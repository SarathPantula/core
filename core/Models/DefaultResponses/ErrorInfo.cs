namespace core.Models.DefaultResponses;

/// <summary>
/// Error Info
/// </summary>
public class ErrorInfo
{
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="errorMessage"></param>
    public ErrorInfo(long errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }
    /// <summary>
    /// Error Code
    /// </summary>
    public long ErrorCode { get; set; }
    /// <summary>
    /// Error Message
    /// </summary>
    public string ErrorMessage { get; set; } = string.Empty;
}
