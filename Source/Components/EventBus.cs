using System;
using Fluiid.Source.Forms;

namespace Fluiid.Source.Components
{
  /// <summary>
  /// Event bus for event handlers
  /// </summary>
  public class EventBus
  {
    /// <summary>
    /// Event handler for event with no parameters
    /// </summary>
    public delegate void ParamlessEventHandler();

    /// <summary>
    /// Application
    /// </summary>
    private App app;

    /// <summary>
    /// Main UI window
    /// </summary>
    private Main main;

    /// <summary>
    /// Communicator
    /// </summary>
    private Communicator communicator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="app">Application</param>
    /// <param name="main">Main UI form</param>
    /// <param name="communicator">Communicator</param>
    public EventBus(App app, Main main,Communicator communicator)
    {
      this.app = app;
      this.main = main;
      this.communicator = communicator;
    }

    /// <summary>
    /// Set Main
    /// </summary>
    /// <param name="main">Main UI window</param>
    public void SetMain(Main main)
    {
      this.main = main;
    }

    /// <summary>
    /// Handler for Worker Start event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void onWorkerStart(object sender, EventArgs e)
    {
      main.Invoke(new App.WorkProcedure(main.AppBusy));
    }

    /// <summary>
    /// Handler for Worker ready event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void onWorkerReady(object sender, EventArgs e)
    {
      main.Invoke(new App.WorkProcedure(main.AppReady));
    }

    /// <summary>
    /// Connect device
    /// </summary>
    public void onConnectClick(object sender, EventArgs e)
    {
      app.RunWorker(new App.WorkProcedure(communicator.Connect));
    }

    /// <summary>
    /// Disconnect device
    /// </summary>
    public void onDisConnectClick(object sender, EventArgs e)
    {
      app.RunWorker(new App.WorkProcedure(communicator.Close));
    }

    /// <summary>
    /// Handler for device connected event
    /// </summary>
    public void onDeviceConnected()
    {
      main.Invoke(new App.WorkProcedure(main.DeviceConnected));
    }

    /// <summary>
    /// Handler for device disconnected event
    /// </summary>
    public void onDeviceDisConnected()
    {
      main.Invoke(new App.WorkProcedure(main.DeviceDisConnected));
    }
  }
}
