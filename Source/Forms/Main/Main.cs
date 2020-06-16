using System;
using System.Windows.Forms;
using Fluiid.Source.Components;

namespace Fluiid.Source.Forms
{
  /// <summary>
  /// Main window
  /// </summary>
  public partial class Main : Form
  {
    /// <summary>
    /// Event bus
    /// </summary>
    private EventBus eventBus;

    /// <summary>
    /// Configurator
    /// </summary>
    private Configurator configurator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="eventBus">Event bus</param>
    /// <param name="configurator">Configurator</param>
    public Main(EventBus eventBus, Configurator configurator)
    {
      InitializeComponent();
      this.eventBus = eventBus;
      this.configurator = configurator;
    }

    /// <summary>
    /// Init form
    /// </summary>
    public void Init()
    {
      // Add Event handlers

      // About
      AboutBtn.Click += new EventHandler(openAbout);

      // Settings
      Settings.Click += new EventHandler(openSettings);

      // Connect device
      ButtonConnect.Click += new EventHandler(eventBus.onConnectClick);

      // Disconnect device
      ButtonDisconnect.Click += new EventHandler(eventBus.onDisConnectClick);

      // Init device
      ButtonInit.Click += new EventHandler(eventBus.onInit);

      // Wash device
      ButtonWash.Click += new EventHandler(eventBus.onWash);

      // Send raw command
      ButtonSend.Click += new EventHandler(onSendCommand);
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
    /// Event handler for sending raw command
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void onSendCommand(object sender, EventArgs e)
    {
      string command = TextBoxCmd.Text;

      // Check if command is presented
      if (command.Trim().Length > 0)
      {
        eventBus.onSend(command);
      }
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
      TextBoxCmd.Enabled = false;
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
      TextBoxCmd.Enabled = true;
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
      TextBoxCmd.Show();
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
      TextBoxCmd.Hide();
    }
  }
}
