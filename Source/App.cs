using System;
using System.ComponentModel;
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
    /// Event Bus
    /// </summary>
    private EventBus eventBus;

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
    /// Background worker
    /// </summary>
    private Worker worker;

    /// <summary>
    /// Main Window
    /// </summary>
    private Forms.Main main;

    /// <summary>
    /// Delegate for work procedures
    /// </summary>
    public delegate void WorkProcedure();

    /// <summary>
    /// Constructor
    /// </summary>
    public App()
    {
      exceptionHandler = null;
      eventBus = null;
      logger = null;
      configurator = null;
      communicator = null;
      worker = null;
      main = null;
    }

    /// <summary>
    /// Run Application
    /// </summary>
    public void Run()
    {
      try
      {
        // Boot components
        Boot();

        // Add event handlers
        AddEventHandlers();

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
    /// Boot components
    /// </summary>
    private void Boot()
    {
      // Exception handler
      exceptionHandler = new ExceptionHandler();

      // Logger
      logger = new FileLogger("log_" + DateTime.Now.ToString("yy-MM-dd") + ".txt");
      logger.Debug("Logger loaded");

      // Logger now ready --> give to ExceptionHandler
      exceptionHandler.SetLogger(ref logger);

      // Configurator
      configurator = new Configurator(this);
      configurator.Init();
      logger.Debug("Configurator loaded");

      // Communicator
      communicator = new Communicator(configurator.Port, ref logger);
      communicator.Init();
      logger.Debug("Communicator loaded");

      // Worker
      worker = new Worker();

      // Event Bus
      eventBus = new EventBus(this, main, communicator);

      // Main window
      main = new Forms.Main(this, eventBus, configurator);
      main.Init();

      // Main now ready --> give to Event bus
      eventBus.SetMain(main);
    }

    /// <summary>
    /// Add Event handlers
    /// </summary>
    private void AddEventHandlers()
    {
      // Communicator
      communicator.Connected += new EventBus.ParamlessEventHandler(eventBus.onDeviceConnected);
      communicator.Disconnected += new EventBus.ParamlessEventHandler(eventBus.onDeviceDisConnected);

      // Worker
      worker.DoWork += new DoWorkEventHandler(eventBus.onWorkerStart);
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(eventBus.onWorkerReady);
    }

    /// <summary>
    /// Run worker
    /// </summary>
    /// <param name="job">Job to work on</param>
    public void RunWorker(WorkProcedure job)
    {
      // Job to work on
      worker.setJob(job);

      // Set UI to busy
      main.AppBusy();

      // Start worker
      worker.RunWorkerAsync();
    }
  }
}
