namespace Fluiid_cs.Source.Exception
{
  /// <summary>
  /// Base Exception
  /// </summary>
  public class BaseException: System.Exception
  {
    /// <summary>
    /// Exception context
    /// </summary>
    protected string context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">Exception context</param>
    /// <param name="message">Exception message</param>
    public BaseException(string context, string message): base(message)
    {
      this.context = context;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">Exception context</param>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public BaseException(string context, string message, System.Exception inner): base(message, inner)
    {
      this.context = context;
    }

    /// <summary>
    /// Get context
    /// </summary>
    /// <returns>Exception context</returns>
    public string GetContext()
    {
      return context;
    }
  }
}
