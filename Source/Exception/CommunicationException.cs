namespace Fluiid_cs.Source.Exception
{
  /// <summary>
  /// Communication Exception
  /// </summary>
  public class CommunicationException: BaseException
  {
    /// <summary>
    /// Exception context
    /// </summary>
    public const string Context = "Communication problem.";
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public CommunicationException(string message) : base(Context, message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public CommunicationException(string message, System.Exception inner) : base(Context, message, inner)
    {
    }
  }
}
