using Fluiid.Source;
using System;
using System.Windows.Forms;

namespace Fluiid
{
  /// <summary>
  /// Program Runner
  /// </summary>
  static class Program
  {
    /// <summary>
    /// App ROOT path
    /// </summary>
    public static string ROOT = Application.StartupPath;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // App properties
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Console.WriteLine("----------------------");
      
      // Boot app
      App app = new App();
      app.Run();
    }

    /// <summary>
    /// Exit application
    /// </summary>
    /// <param name="code">Exit code</param>
    public static void Exit(int code=0)
    {
      // If Application started (WinForms)
      if (Application.MessageLoop)
      {
        Application.Exit();
      }
      else
      {
        Environment.Exit(code);
      }
    }
  }
}
