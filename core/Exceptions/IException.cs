namespace core.Exceptions;

/// <summary>
/// IException
/// </summary>
public interface IException
{
    /// <summary>
    /// Error Code
    /// </summary>
    public int ErrorCode { get; }
}