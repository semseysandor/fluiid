namespace Fluiid_cs.Source.Exception
{
  /// <summary>
  /// Logger Exception
  /// </summary>
  public class LoggerException : BaseException
  {
    /// <summary>
    /// Exception context
    /// </summary>
    public const string Context = "Logging problem.";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public LoggerException(string message) : base(Context, message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public LoggerException(string message, System.Exception inner) : base(Context, message, inner)
    {
    }
  }
}
