using System;
using System.Windows.Forms;

namespace Fluiid_cs.Source.Forms
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
    /// About modal
    /// </summary>
    private Form about;

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
      ButtonConnect.Click += new EventHandler(app.ConnectDevice);
      AboutToolStripMenuItem.Click += new EventHandler(openAbout);
    }

    /// <summary>
    /// Open About modal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void openAbout(object sender, EventArgs e)
    {
      about = new About();
      about.StartPosition = FormStartPosition.CenterParent;
      about.ShowDialog(this);
    }
  }
}
