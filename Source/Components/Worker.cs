using System.ComponentModel;

namespace Fluiid.Source.Components
{
  /// <summary>
  /// Background worker for async jobs
  /// </summary>
  class Worker : BackgroundWorker
  {
    /// <summary>
    /// Actual job
    /// </summary>
    private App.WorkProcedure job;

    /// <summary>
    /// Constructor
    /// </summary>
    public Worker()
    {
      this.DoWork += Run;
    }

    /// <summary>
    /// Set job
    /// </summary>
    /// <param name="job">Job to work</param>
    public void setJob(App.WorkProcedure job)
    {
      this.job = job;
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
  }
}
