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
    /// UI worker
    /// </summary>
    private MainUIWorker ui;

    /// <summary>
    /// Constructor
    /// </summary>
    public Main(App app)
    {
      InitializeComponent();
      this.app = app;    
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
      ButtonConnect.Click += new EventHandler(app.ConnectDevice);
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
      Settings.Settings settings = new Settings.Settings
      {
        StartPosition = FormStartPosition.CenterParent
      };
      settings.Init();
      settings.ShowDialog(this);
    }
  }
}
