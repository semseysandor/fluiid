using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluiid.Source.Components.Logger
{
  /// <summary>
  /// Logging level
  /// </summary>
  class LogLevels
  {
    /// <summary>
    /// Debug information
    /// </summary>
    public const int Debug = 0;

    /// <summary>
    /// Information
    /// </summary>
    public const int Info = 1;

    /// <summary>
    /// Warning
    /// </summary>
    public const int Warning = 2;

    /// <summary>
    /// Not critical error
    /// </summary>
    public const int Error = 3;

    /// <summary>
    /// Critical Error
    /// </summary>
    public const int Critical = 4;

    /// <summary>
    /// Logging off
    /// </summary>
    public const int Off = 5;

    /// <summary>
    /// Return log level string
    /// </summary>
    /// <param name="loglevel">Log level integer</param>
    /// <returns></returns>
    public static string LogLevelToString(int loglevel)
    {
      switch (loglevel) {
        case LogLevels.Debug:
          return "Debug";
        case LogLevels.Info:
          return "Info";
        case LogLevels.Warning:
          return "Warning";
        case LogLevels.Error:
          return "Error";
        case LogLevels.Critical:
          return "Critical";
        case LogLevels.Off:
          return "Off";
        default:
          return "";
      }
    }

    /// <summary>
    /// Return log level string
    /// </summary>
    /// <param name="loglevel">Log level string</param>
    /// <returns></returns>
    public static int LogLevelFromString(string loglevel)
    {
      switch (loglevel)
      {
        case "Debug":
          return LogLevels.Debug;
        case "Info":
          return LogLevels.Info;
        case "Warning":
          return LogLevels.Warning;
        case "Error":
          return LogLevels.Error;
        case "Critical":
          return LogLevels.Critical;
        case "Off":
          return LogLevels.Off;
        default:
          return 0;
      }
    }
  }
}
