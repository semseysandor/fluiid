namespace Fluiid.Source.Forms
{
  /// <summary>
  /// UI worker for main window
  /// </summary>
  class MainUIWorker
  {
    /// <summary>
    /// Main form to work on
    /// </summary>
    private Main form;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="main">Main form</param>
    public MainUIWorker(Main main)
    {
      form = main;
    }

    /// <summary>
    /// Set main window busy for users 
    /// </summary>
    public void SetBusy()
    {
      form.ButtonDisconnect.Enabled = false;
      form.ButtonInit.Enabled = false;
      form.ButtonWash.Enabled = false;
      form.ButtonSend.Enabled = false;
      form.UseWaitCursor = true;
    }

    /// <summary>
    /// Set main window ready for users
    /// </summary>
    public void ClearBusy()
    {
      form.ButtonDisconnect.Enabled = true;
      form.ButtonInit.Enabled = true;
      form.ButtonWash.Enabled = true;
      form.ButtonSend.Enabled = true;
      form.UseWaitCursor = false;
    }
  }
}
