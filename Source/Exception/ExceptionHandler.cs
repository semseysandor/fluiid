using System.Windows.Forms;
using Fluiid.Source.Components.Logger;

namespace Fluiid.Source.Exception
{
  /// <summary>
  /// Exception Handler
  /// </summary>
  public class ExceptionHandler
  {
    /// <summary>
    /// Logger
    /// </summary>
    private Logger logger;

    /// <summary>
    /// Parent window
    /// </summary>
    private IWin32Window appWindow;

    /// <summary>
    /// Constructor
    /// </summary>
    public ExceptionHandler()
    {
      appWindow = null;
      logger = null;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appWindow">Parent window</param>
    /// <param name="logger">Logger</param>
    public ExceptionHandler(IWin32Window appWindow, ref Logger logger)
    {
      this.appWindow = appWindow;
      this.logger = logger;
    }

    /// <summary>
    /// Set Logger
    /// </summary>
    /// <param name="logger">Logger</param>
    public void SetLogger(ref Logger logger)
    {
      this.logger = logger;
    }

    /// <summary>
    /// Set parent window
    /// </summary>
    /// <param name="appWindow">Parent window</param>
    public void SetWindow(ref IWin32Window appWindow)
    {
      this.appWindow = appWindow;
    }

    /// <summary>
    /// Handling Error
    /// </summary>
    /// <param name="ex">Exception</param>
    public void handleError(System.Exception ex)
    {
      LogError(ex);
      ShowError(ex.Message, "Misc Exception");
    }

    /// <summary>
    /// Handling Logging errors
    /// </summary>
    /// <param name="ex">Exception</param>
    public void handleLoggingError(LoggerException ex)
    {
      ShowError(ex.Message, ex.Context);   
    }

    /// <summary>
    /// HandleFatalErrors
    /// </summary>
    /// <param name="ex">Exception</param>
    public void handleFatalError(BaseException ex)
    {
      LogError(ex);
      ShowError(ex.Message, ex.Context);
      callExit();
    }

    /// <summary>
    /// Show Error box to user
    /// </summary>
    /// <param name="text">Exception text</param>
    /// <param name="context">Exception context</param>
    protected void ShowError(string text, string context)
    {
      if (appWindow is null)
      {
        MessageBox.Show(text, "Fluiid - "+context, MessageBoxButtons.OK, MessageBoxIcon.Error);
      } else
      {
        MessageBox.Show(appWindow, text, "Fluiid - Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Log error
    /// </summary>
    /// <param name="ex">Exception</param>
    protected void LogError(BaseException ex)
    {
      if (!(logger is null))
      {
        logger.Error(ex.Message);
        logger.Error(ex.Context);
        logger.Debug(ex.InnerException.Message);
      }
    }

    /// <summary>
    /// Log error
    /// </summary>
    /// <param name="ex">Exception</param>
    protected void LogError(System.Exception ex)
    {
      if (!(logger is null))
      {
        logger.Error(ex.Message);
      }
    }

    /// <summary>
    /// Call application exit;
    /// </summary>
    /// <param name="code"></param>
    protected void callExit(int code=1)
    {
      Program.Exit(code);
    }
  }
}
