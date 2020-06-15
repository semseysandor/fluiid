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
      // Add Event handlers

      // About
      AboutToolStripMenuItem.Click += new EventHandler(openAbout);

      // Settings
      Settings.Click += new EventHandler(openSettings);

      // Connect device
      ButtonConnect.Click += new EventHandler(app.DeviceConnect);

      // Disconnect device
      ButtonDisconnect.Click += new EventHandler(app.DeviceDisConnect);
    }

    /// <summary>
    /// Open About modal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void openAbout(object sender, EventArgs e)
    {
      About about = new About();
      about.StartPosition = FormStartPosition.CenterParent;
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
    /// Set Main App window busy
    /// </summary>
    public void AppBusy()
    {
      ButtonConnect.Enabled = false;
      ButtonDisconnect.Enabled = false;
      ButtonInit.Enabled = false;
      ButtonWash.Enabled = false;
      ButtonSend.Enabled = false;
      UseWaitCursor = true;
    }

    /// <summary>
    /// Set Main App window ready
    /// </summary>
    public void AppReady()
    {
      ButtonConnect.Enabled = true;
      ButtonDisconnect.Enabled = true;
      ButtonInit.Enabled = true;
      ButtonWash.Enabled = true;
      ButtonSend.Enabled = true;
      UseWaitCursor = false;
    }

    /// <summary>
    /// Device Connected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeviceConnected()
    {
      TextConnection.Text = "Connected";
      ButtonConnect.Hide();
      ButtonDisconnect.Show();
      ButtonInit.Show();
      ButtonWash.Show();
      ButtonSend.Show();
    }

    /// <summary>
    /// Device disconnected
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeviceDisConnected()
    {
      TextConnection.Text = "Disconnected";
      ButtonConnect.Show();
      ButtonDisconnect.Hide();
      ButtonInit.Hide();
      ButtonWash.Hide();
      ButtonSend.Hide();
    }
  }
}
