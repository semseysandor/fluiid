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
    /// Controller
    /// </summary>
    private Controller controller;

    /// <summary>
    /// Main Window
    /// </summary>
    private Forms.Main main;

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
      controller = null;
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
      logger.Debug("Logger loaded.");

      // Logger now ready --> give to ExceptionHandler
      exceptionHandler.SetLogger(logger);

      // Configurator
      configurator = new Configurator();
      configurator.Init();
      logger.Debug("Configurator loaded.");

      // Communicator
      communicator = new Communicator(configurator.Port, logger);
      communicator.Init();
      logger.Debug("Communicator loaded.");

      // Controller
      controller = new Controller(logger, communicator);
      logger.Debug("Controller loaded.");

      // Event Bus
      eventBus = new EventBus(this, main, communicator, controller);

      // Main window
      main = new Forms.Main(eventBus, configurator);
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
    }

    /// <summary>
    /// Run worker
    /// </summary>
    /// <param name="job">Job to work on</param>
    public void RunWorker(Worker.Job job)
    {
      // Create worker
      Worker worker = new Worker(job);

      // Add worker events
      AddWorkerEvents(ref worker);

      // Set UI to busy
      main.AppBusy();

      // Start worker
      worker.RunWorkerAsync();
    }

    /// <summary>
    /// Run worker
    /// </summary>
    /// <param name="job">Job to work on</param>
    public void RunWorker(Controller.CommandDelegate job, string param)
    {
      // Create new worker
      Worker worker = new Worker(job);

      // Add worker events
      AddWorkerEvents(ref worker);

      // Set UI to busy
      main.AppBusy();

      // Start worker
      worker.RunWorkerAsync(argument: param);
    }

    /// <summary>
    /// Add Event handlers to worker
    /// </summary>
    /// <param name="worker">Worker to add handlers</param>
    private void AddWorkerEvents(ref Worker worker)
    {
      // Set App UI to ready
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(eventBus.onWorkerReady);

      // Add exception handling to worker
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WorkerErrorHandling);
    }
    /// <summary>
    /// Error handling for worker jobs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void WorkerErrorHandling(object sender, RunWorkerCompletedEventArgs e)
    {
      Worker worker = (Worker)sender;

      // Remove this event handler to allow garbage collection on the worker later
      worker.RunWorkerCompleted -= WorkerErrorHandling;

      // No exception --> worker finished OK --> do nothing
      if (e.Error is null)
      {
        return;
      }

      // Handle exception according to its type
      switch (e.Error)
      {
        case LoggerException loggerException:
          exceptionHandler.handleLoggingError(loggerException);
          break;
        case BaseException baseException:
          exceptionHandler.handleError(baseException);
          break;
        case System.Exception exception:
          exceptionHandler.handleError(exception);
          break;
      }
    }
  }
}
