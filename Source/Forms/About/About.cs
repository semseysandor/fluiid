using System;
using System.Windows.Forms;

namespace Fluiid.Source.Forms
{
  /// <summary>
  /// About modal
  /// </summary>
  public partial class About : Form
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public About()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Close button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Loader
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Loader(object sender, EventArgs e)
    {
      TextInfo.Text =
      "Fluiid v0.6" + Environment.NewLine +
      "Developed by:" + Environment.NewLine +
      "Sandor Semsey" + Environment.NewLine +
      "Copyright 2020";
    }
  }
}
