using System;
using System.Windows.Forms;
using Fluiid.Source.Components;
using Fluiid.Source.Components.Logger;
using Fluiid.Source.Exception;

namespace Fluiid.Source
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
    /// Constructor
    /// </summary>
    public App()
    {
      configurator = null;
      main = null;
    }

    /// <summary>
    /// Boot components
    /// </summary>
    private void Boot()
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

      // Boot Communicator
      communicator = new Communicator(configurator.Port, ref logger);
      communicator.Boot();
      logger.Debug("Communicator loaded");

      // Init main window
      main = new Forms.Main(this);
      main.Init();
    }

    /// <summary>
    /// Boot Application
    /// </summary>
    public void Run()
    {
      try
      {
        // Boot components
        Boot();

        // Run application
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

    /// <summary>
    /// Connect device
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ConnectDevice(object sender, EventArgs e)
    {
      Console.WriteLine("fakkala maske");
      throw new System.Exception("bre");
    }
  }
}
