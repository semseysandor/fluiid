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
      logger = null;
      configurator = null;
      communicator = null;
      worker = null;
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
      communicator.Connected += new EventHandler(onDeviceConnected);
      communicator.Disconnected += new EventHandler(onDeviceDisConnected);
      logger.Debug("Communicator loaded");

      // Init worker
      worker = new Worker();
      worker.DoWork += new DoWorkEventHandler(onWorkerStart);
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(onWorkerReady);

      // Init main window
      main = new Forms.Main(this, configurator);
      main.Init();
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
    /// Handler for Worker Start event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void onWorkerStart(object sender, EventArgs e)
    {
      main.Invoke(new WorkProcedure(main.AppBusy));
    }

    /// <summary>
    /// Handler for Worker ready event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void onWorkerReady(object sender, EventArgs e)
    {
      main.Invoke(new WorkProcedure(main.AppReady));
    }

    /// <summary>
    /// Runs worker
    /// </summary>
    /// <param name="job">Job to work on</param>
    private void RunWorker(WorkProcedure job)
    {
      // Job to work on
      worker.setJob(job);

      // Set UI to busy
      main.AppBusy();

      // Start worker
      worker.RunWorkerAsync();
    }

    /// <summary>
    /// Connect device
    /// </summary>
    public void DeviceConnect(object sender, EventArgs e)
    { 
      RunWorker(new WorkProcedure(communicator.Connect));
    }

    /// <summary>
    /// Disconnect device
    /// </summary>
    public void DeviceDisConnect(object sender, EventArgs e)
    {
      RunWorker(new WorkProcedure(communicator.Close));
    }

    /// <summary>
    /// Handler for device connected event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void onDeviceConnected(object sender, EventArgs e)
    {
      main.Invoke(new WorkProcedure(main.DeviceConnected));
    }

    /// <summary>
    /// Handler for device disconnected event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void onDeviceDisConnected(object sender, EventArgs e)
    {
      main.Invoke(new WorkProcedure(main.DeviceDisConnected));
    }
  }
}
