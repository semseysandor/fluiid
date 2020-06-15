namespace Fluiid.Source.Exception
{
  /// <summary>
  /// Base Exception
  /// </summary>
  public class BaseException: System.Exception
  {
    /// <summary>
    /// Exception context
    /// </summary>
    public string Context { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">Exception context</param>
    /// <param name="message">Exception message</param>
    public BaseException(string context, string message): base(message)
    {
      Context = context;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">Exception context</param>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public BaseException(string context, string message, System.Exception inner): base(message, inner)
    {
      Context = context;
    }
  }
}
