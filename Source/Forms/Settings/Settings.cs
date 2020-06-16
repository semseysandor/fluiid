using System;
using System.Windows.Forms;
using Fluiid.Source.Components.Logger;

namespace Fluiid.Source.Forms.Settings
{
  /// <summary>
  /// Settings form
  /// </summary>
  public partial class Settings : Form
  {
    /// <summary>
    /// Configurator
    /// </summary>
    private Configurator configurator;

    /// <summary>
    /// Actual port
    /// </summary>
    private string port;

    /// <summary>
    /// Actual logging level
    /// </summary>
    private int LogLevel;

    /// <summary>
    /// Constructor
    /// </summary>
    public Settings(Configurator configurator)
    {
      InitializeComponent();
      this.configurator = configurator;
    }

    /// <summary>
    /// Init form
    /// </summary>
    public void Init()
    {
      // Add available options
      string[] portsList = { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", };
      string[] loglevels = { "Error", "Warning", "Info", "Debug", "Off" };

      ports.Items.AddRange(portsList);
      logging.Items.AddRange(loglevels);

      // Load actual configs
      LoadConfigs();

      // Add Event handlers
      close.Click += new EventHandler(OnClickClose);
    }

    /// <summary>
    /// Load configs
    /// </summary>
    protected void LoadConfigs()
    {
      // Actual values
      port = configurator.Port;
      LogLevel = configurator.LogLevel;

      // Cycle through ports
      foreach (object item in ports.Items)
      {
        if (item.ToString() == port)
        {
          ports.SelectedItem = item;
        }
      }

      // Cycle through loglevels
      foreach (object item in logging.Items)
      {
        if (item.ToString() == LogLevels.LogLevelToString(LogLevel))
        {
          logging.SelectedItem = item;
        }
      }
    }

    /// <summary>
    /// Close form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClickClose(object sender, EventArgs e)
    {
      // Write selected values
      configurator.Port = ports.SelectedItem.ToString();
      configurator.LogLevel = LogLevels.LogLevelFromString(logging.SelectedItem.ToString());

      // Close form
      Close();
    }
  }
}
