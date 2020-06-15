using System;
using System.Windows.Forms;

namespace Fluiid.Source.Forms
{
  /// <summary>
  /// Main window
  /// </summary>
  public partial class Main : Form
  {
    /// <summary>
    /// Application
    /// </summary>
    private App app;

    /// <summary>
    /// Configurator
    /// </summary>
    private Configurator configurator;

    /// <summary>
    /// UI worker
    /// </summary>
    private MainUIWorker ui;

    /// <summary>
    /// Constructor
    /// </summary>
    public Main(App app, Configurator configurator)
    {
      InitializeComponent();
      this.app = app;
      this.configurator = configurator;
    }

    /// <summary>
    /// Init form
    /// </summary>
    public void Init()
    {
      // Create UI worker
      ui = new MainUIWorker(this);

      // Event handlers
      AddEventHandlers();
    }

    /// <summary>
    /// Add event handlers
    /// </summary>
    private void AddEventHandlers()
    {
      // About
      AboutToolStripMenuItem.Click += new EventHandler(openAbout);

      // Settings
      Settings.Click += new EventHandler(openSettings);

      // Connect device
      ButtonConnect.Click += new EventHandler(this.ConnectDevice);

      // Disconnect device
      ButtonDisconnect.Click += new EventHandler(this.DisConnectDevice);
    }

    /// <summary>
    /// Open About modal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void openAbout(object sender, EventArgs e)
    {
      About about = new About
      {
        StartPosition = FormStartPosition.CenterParent
      };
      about.Init();
      about.ShowDialog(this);
    }

    /// <summary>
    /// Open Settings
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void openSettings(object sender, EventArgs e)
    {
      Settings.Settings settings = new Settings.Settings(configurator);
      settings.StartPosition = FormStartPosition.CenterParent;
      settings.Init();
      settings.ShowDialog(this);
    }

    /// <summary>
    /// Connect device
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ConnectDevice(object sender, EventArgs e)
    {
      // Set application UI to busy
      ui.SetBusy();
      app.DeviceConnect();
    }

    /// <summary>
    /// Disconnect device
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DisConnectDevice(object sender, EventArgs e)
    {
      // Set application UI to busy
      ui.SetBusy();
      app.DeviceDisConnect();
    }

    /// <summary>
    /// Device Connected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeviceConnected(object sender, EventArgs e)
    {
      // Set application UI
      ui.ClearBusy();
      ui.Connected();
    }

    /// <summary>
    /// Device disconnected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeviceDisConnected(object sender, EventArgs e)
    {
      // Set application UI
      ui.ClearBusy();
      ui.DisConnected();
    }
  }
}
