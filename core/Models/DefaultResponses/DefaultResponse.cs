namespace core.Models.DefaultResponses;

public abstract class DefaultResponse : IDefaultResponse
{
    /// <summary>
    /// 
    /// </summary>
    public List<ErrorInfo> Errors { get; set; } = new List<ErrorInfo>();
}
