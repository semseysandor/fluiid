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
    public const string DEF_CONTEXT = "Communication problem.";
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    public CommunicationException(string message) : base(DEF_CONTEXT, message)
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="inner">Inner exception</param>
    public CommunicationException(string message, System.Exception inner) : base(DEF_CONTEXT, message, inner)
    {
    }
  }
}
