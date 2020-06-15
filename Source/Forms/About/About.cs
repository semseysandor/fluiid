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
    /// Init form components
    /// </summary>
    public void Init()
    {
      // Add event handlers

      // Load form contents
      this.Load += new EventHandler(Loader);

      // Close button
      CloseBtn.Click += new EventHandler(onClickClose);
    }

    /// <summary>
    /// Close form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void onClickClose(object sender, EventArgs e)
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
      Console.WriteLine("joco");
      TextInfo.Text =
      "Fluiid v0.6" + Environment.NewLine +
      "Developed by:" + Environment.NewLine +
      "Sandor Semsey" + Environment.NewLine +
      "Copyright 2020";
    }
  }
}
