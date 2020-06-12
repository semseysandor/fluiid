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
    public const string DEF_CONTEXT = "Logging problem.";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public LoggerException(string message) : base(DEF_CONTEXT, message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public LoggerException(string message, System.Exception inner) : base(DEF_CONTEXT, message, inner)
    {
    }
  }
}
