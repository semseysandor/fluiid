using System;
using System.IO.Ports;
using System.Windows.Forms;
using Fluiid_cs.Source.Components;
using Fluiid_cs.Source.Components.Logger;
using Fluiid_cs.Source.Exception;

namespace Fluiid_cs.Source
{
  /// <summary>
  /// Application
  /// </summary>
  public class App
  {
    /// <summary>
    /// Exception Handler
    /// </summary>
    private ExceptionHandler exceptionHandler;

    /// <summary>
    /// Logger
    /// </summary>
    private Logger logger;

    /// <summary>
    /// Configurator
    /// </summary>
    private Configurator configurator;

    /// <summary>
    /// Communicator
    /// </summary>
    private Communicator communicator;

    /// <summary>
    /// Main Window
    /// </summary>
    private Forms.Main main;

    /// <summary>
    /// App Constructor
    /// </summary>
    public App()
    {
      configurator = null;
      main = null;
    }

    /// <summary>
    /// Boot Application
    /// </summary>
    public void Boot()
    {
      try
      {
        // Boot Exception handler
        exceptionHandler = new ExceptionHandler();

        // Boot Logger
        logger = new FileLogger("log_" + DateTime.Now.ToString("yy-MM-dd") + ".txt");
        logger.Debug("Logger loaded");

        // Logger now ready --> give to ExceptionHandler
        exceptionHandler.SetLogger(ref logger);

        // Boot Configurator
        configurator = new Configurator(this);
        configurator.Boot();
        logger.Debug("Configurator loaded");

        // Boot communicator
        communicator = new Communicator(configurator.Port, ref logger);
        communicator.Boot();
        logger.Debug("Communicator loaded");

        main = new Forms.Main();
        Application.Run(main);
      }
      catch (LoggerException ex)
      {
        exceptionHandler.handleLoggingError(ex);
      }
      catch (BaseException ex)
      {
        exceptionHandler.handleFatalError(ex);
      }
      catch (System.Exception ex)
      {
        exceptionHandler.handleError(ex);
      }
    }
  }
}
