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
    /// About modal
    /// </summary>
    private Form about;

    /// <summary>
    /// Constructor
    /// </summary>
    public Main()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Open About modal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void openAbout(object sender, System.EventArgs e)
    {
      about = new About();
      about.StartPosition = FormStartPosition.CenterParent;
      about.ShowDialog(this);
    }
  }
}
