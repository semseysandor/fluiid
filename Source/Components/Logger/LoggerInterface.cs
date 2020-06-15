using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluiid.Source.Components.Logger
{
  /// <summary>
  /// Logger interface
  /// </summary>
  public interface LoggerInterface
  {
    /// <summary>
    /// Logs a critical event
    /// </summary>
    /// <param name="message">Message to log</param>
    void Critical(string message);

    /// <summary>
    /// Logs an error
    /// </summary>
    /// <param name="message">Message to log</param>
    void Error(string message);

    /// <summary>
    /// Logs a warning
    /// </summary>
    /// <param name="message">Message to log</param>
    void Warning(string message);

    /// <summary>
    /// Logs some information
    /// </summary>
    /// <param name="message">Message to log</param>
    void Info(string message);

    /// <summary>
    /// Logs debug messages
    /// </summary>
    /// <param name="message">Message to log</param>
    void Debug(string message);

    /// <summary>
    /// Logs a message at a given level
    /// </summary>
    /// <param name="level">Message level</param>
    /// <param name="message">Message to log</param>
    void Log(int level, string message);
  }
}
