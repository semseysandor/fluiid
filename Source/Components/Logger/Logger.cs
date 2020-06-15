using System.Linq;

namespace Fluiid.Source.Components.Logger
{
  /// <summary>
  /// Base logger class
  /// </summary>
  public abstract class Logger : LoggerInterface
  {
    /// <summary>
    /// Actual logging level
    /// </summary>
    public int LogLevel { get; set; } = LogLevels.Debug;

    /// <summary>
    /// Logs a critical event
    /// </summary>
    /// <param name="message">Message to log</param>
    public void Critical(string message)
    {
      Log(LogLevels.Critical, message);
    }

    /// <summary>
    /// Logs an error
    /// </summary>
    /// <param name="message">Message to log</param>
    public void Error(string message)
    {
      Log(LogLevels.Error, message);
    }

    /// <summary>
    /// Logs a warning
    /// </summary>
    /// <param name="message">Message to log</param>
    public void Warning(string message)
    {
      Log(LogLevels.Warning, message);
    }

    /// <summary>
    /// Logs some information
    /// </summary>
    /// <param name="message">Message to log</param>
    public void Info(string message)
    {
      Log(LogLevels.Info, message);
    }

    /// <summary>
    /// Logs debug messages
    /// </summary>
    /// <param name="message">Message to log</param>
    public void Debug(string message)
    {
      Log(LogLevels.Debug, message);
    }

    /// <summary>
    /// Logs a message at a given level
    /// </summary>
    /// <param name="level">Message level</param>
    /// <param name="message">Message to log</param>
    public abstract void Log(int level, string message);

    /// <summary>
    /// Returns the message level string
    /// </summary>
    /// <param name="msglevel">Message level</param>
    /// <returns>Message level string</returns>
    protected string MessageLevel(int msglevel)
    {
      switch (msglevel)
      {
        case LogLevels.Debug:
          {
            return "DEBUG   ";
          }

        case LogLevels.Info:
          {
            return "INFO    ";
          }

        case LogLevels.Warning:
          {
            return "WARNING ";
          }

        case LogLevels.Error:
          {
            return "ERROR   ";
          }

        case LogLevels.Critical:
          {
            return "CRITICAL";
          }

        default:
          {
            return "";
          }
      }
    }
  }
}
