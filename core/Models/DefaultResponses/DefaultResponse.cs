namespace core.Models.DefaultResponses;

/// <summary>
/// Default Response
/// </summary>
public abstract class DefaultResponse : IDefaultResponse
{
    /// <summary>
    /// Errors
    /// </summary>
    public List<ErrorInfo> Errors { get; set; } = new List<ErrorInfo>();
}
