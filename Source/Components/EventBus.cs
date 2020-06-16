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
    /// Controller
    /// </summary>
    private Controller controller;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="app">Application</param>
    /// <param name="main">Main UI form</param>
    /// <param name="communicator">Communicator</param>
    public EventBus(App app, Main main, Communicator communicator, Controller controller)
    {
      this.app = app;
      this.main = main;
      this.communicator = communicator;
      this.controller = controller;
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
    /// Handler for Worker ready event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void onWorkerReady(object sender, EventArgs e)
    {
      main.Invoke(new Worker.Job(main.AppReady));
    }

    /// <summary>
    /// Connect device
    /// </summary>
    public void onConnectClick(object sender, EventArgs e)
    {
      app.RunWorker(new Worker.Job(communicator.Connect));
    }

    /// <summary>
    /// Disconnect device
    /// </summary>
    public void onDisConnectClick(object sender, EventArgs e)
    {
      app.RunWorker(new Worker.Job(communicator.Close));
    }

    /// <summary>
    /// Handler for device connected event
    /// </summary>
    public void onDeviceConnected()
    {
      main.Invoke(new Worker.Job(main.DeviceConnected));
    }

    /// <summary>
    /// Handler for device disconnected event
    /// </summary>
    public void onDeviceDisConnected()
    {
      main.Invoke(new Worker.Job(main.DeviceDisConnected));
    }

    /// <summary>
    /// Init device
    /// </summary>
    public void onInit(object sender, EventArgs e)
    {
      app.RunWorker(new Worker.Job(controller.Init));
    }

    /// <summary>
    /// Wash device
    /// </summary>
    public void onWash(object sender, EventArgs e)
    {
      app.RunWorker(new Worker.Job(controller.Wash));
    }

    /// <summary>
    /// Send raw command
    /// </summary>
    public void onSend(string command)
    {
      app.RunWorker(new Controller.CommandDelegate(controller.Command), command);
    }
  }
}
