using System;
using System.Windows.Forms;

namespace Fluiid.Source.Forms.Settings
{
  /// <summary>
  /// Settings form
  /// </summary>
  public partial class Settings : Form
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public Settings()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Init form
    /// </summary>
    public void Init()
    {
      // Add Event handlers
      // Close button
      close.Click += new EventHandler(OnClickClose);
    }

    /// <summary>
    /// Close form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnClickClose(object sender, EventArgs e)
    {
      Close();
    }
  }
}
