using System;
using Fluiid_cs.Source.Exception;

namespace Fluiid_cs.Source.Components.Logger
{
  /// <summary>
  /// Write Log to File
  /// </summary>
  public class FileLogger : Logger
  {
    /// <summary>
    /// Log file path
    /// </summary>
    public string LogFile { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="path">Log file path</param>
    public FileLogger(string path = "")
    {
      LogFile = path;
    }

    /// <summary>
    /// Logs message
    /// </summary>
    /// <param name="msgLevel">Message Level</param>
    /// <param name="message">Message to log</param>
    public override void Log(int msgLevel, string message)
    {
      try
      {
        // No log file specified --> abort
        if (LogFile == null)
        {
          return;
        }

        // If message level is hugher than log level --> important msg, log it
        if (msgLevel >= LogLevel)
        {
          // Also write to console
          Console.WriteLine(message);

          // Compose log line
          message = "[" + MessageLevel(msgLevel) + "] [" + DateTime.Now.ToString() + "] " + message + Environment.NewLine;

          // Write to log
          System.IO.File.AppendAllText(LogFile, message);
        }    
      }
      catch (System.Exception ex)
      {
        throw new LoggerException("Logging failed.", ex);
      }
    }
  }
}
