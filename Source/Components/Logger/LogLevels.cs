using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluiid_cs.Source.Components.Logger
{
  /// <summary>
  /// Logging level
  /// </summary>
  class LogLevels
  {
    /// <summary>
		/// Log all
		/// </summary>
    public const int All = 0;

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
  }
}
