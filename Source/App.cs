using System;
using System.Windows.Forms;

namespace Fluiid_cs.Source
{
  /// <summary>
  /// Application
  /// </summary>
  public class App
  {
    /// <summary>
    /// Configurator
    /// </summary>
    private Configurator configurator;

    /// <summary>
    /// Main Window
    /// </summary>
    private Forms.Main main;

    /// <summary>
    /// App Constructor
    /// </summary>
    public App()
    {
      configurator = null;
      main = null;
    }

    /// <summary>
    /// Boot Application
    /// </summary>
    public void Boot()
    {
      try
      {
        // Boot Configurator
        configurator = new Configurator(this);
        if (configurator.Boot() is false)
        {
          throw new Exception("config problem");
        }

        main = new Forms.Main();
        Application.Run(main);

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        Program.Exit();
      }
    }
  }
}
