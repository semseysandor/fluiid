using System;
using System.Windows.Forms;
using Fluiid_cs.Source.Components.Logger;

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
    /// Logger
    /// </summary>
    private FileLogger logger;

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
        // Boot Logger
        logger = new FileLogger();
        logger.LogFile = "log_" + DateTime.Now.ToString("yy-MM-dd") + ".txt";
        logger.Debug("Logger loaded");

        // Boot Configurator
        configurator = new Configurator(this);
        if (configurator.Boot() is false)
        {
          throw new Exception("config problem");
        }
        logger.Debug("Configurator loaded");

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
