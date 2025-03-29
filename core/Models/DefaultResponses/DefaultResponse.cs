namespace core.Models.DefaultResponses;

/// <summary>
/// Default Response
/// </summary>
public abstract class DefaultResponse : IDefaultResponse
{
    /// <summary>
    /// Ctor
    /// </summary>
    protected DefaultResponse()
    {
        Errors = [];
    }

    /// <summary>
    /// Errors
    /// </summary>
    public List<ErrorInfo> Errors { get; set; }
}
