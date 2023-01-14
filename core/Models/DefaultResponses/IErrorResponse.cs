namespace core.Models.DefaultResponses;

/// <summary>
/// IErrorResponse
/// </summary>
public interface IErrorResponse
{
    /// <summary>
    /// Errors
    /// </summary>
    public List<ErrorInfo> Errors { get; set; }
}
