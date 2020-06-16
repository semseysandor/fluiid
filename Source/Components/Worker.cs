using System.ComponentModel;

namespace Fluiid.Source.Components
{
  /// <summary>
  /// Background worker for async jobs
  /// </summary>
  public class Worker : BackgroundWorker
  {
    /// <summary>
    /// Job delegate
    /// </summary>
    public delegate void Job();

    /// <summary>
    /// Actual job
    /// </summary>
    private Job job;

    /// <summary>
    /// Command job
    /// </summary>
    private Controller.CommandDelegate jobCommand;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="job">Job to work on</param>
    public Worker(Job job)
    {
      this.job = job;
      this.DoWork += Run;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="job">Job to work on</param>
    public Worker(Controller.CommandDelegate job)
    {
      this.jobCommand = job;
      this.DoWork += RunCommand;
    }

    /// <summary>
    /// Run worker
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Run(object sender, DoWorkEventArgs e)
    {
      job.Invoke();
    }

    /// <summary>
    /// Run worker
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RunCommand(object sender, DoWorkEventArgs e)
    {
      string param = e.Argument.ToString();
      jobCommand.Invoke(param);
    }
  }
}
