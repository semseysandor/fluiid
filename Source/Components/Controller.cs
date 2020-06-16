namespace Fluiid.Source.Components
{
  /// <summary>
  /// Controller
  /// </summary>
  class Controller
  {
    /// <summary>
    /// Communicator
    /// </summary>
    private Communicator communicator;

    /// <summary>
    /// Logger
    /// </summary>
    private Logger.Logger logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="communicator">Communicator</param>
    public Controller(Logger.Logger logger, Communicator communicator)
    {
      this.communicator = communicator;
      this.logger = logger;
    }

    /// <summary>
    /// Executes a command on the device
    /// </summary>
    /// <param name="cmd">Command</param>
    public bool Command(string cmd)
    {
      int response;

      // If device not ready --> dont send command
      if (communicator.WaitForDevice() != Communicator.Status.READY)
      {
        return false;
      }

      // Send command & check if failed
      if (communicator.Send(cmd) == false)
      {
        return false;
      }

      // Check device response to command
      response = communicator.Ack();

      // Parse response
      switch (response)
      {
        case Communicator.Status.BUSY:
        case Communicator.Status.READY:
          return true;
        case Communicator.Status.ERROR:
          return false;
        default:
          return false;
      }
    }

    /// <summary>
    /// Requests report from device
    /// </summary>
    /// <param name="command">Report command</param>
    /// <returns>Answer from device</returns>
    public string Report(string command)
    {
      return communicator.Report(command);
    }

    /// <summary>
    /// Initializes device
    /// </summary>
    public void Init()
    {
      // Send initialize command & check if failed
      if (Command("ZR") == false)
      {
        return;
      }

      // Wait for device to finish
      if (communicator.WaitForDevice() == Communicator.Status.READY)
      {
        logger.Info("Initialized");
      }
    }

    /// <summary>
    /// Wash procedure
    /// </summary>
    public void Wash()
    {
      // Set valve to output
      if (Command("OR") == false)
      {
        return;
      }

      // Move plunger to zero position
      if (Command("A0R") == false)
      {
        return;
      }

      // Set valve to input
      if (Command("IR") == false)
      {
        return;
      }

      // Move plunger to max position (fill up syringe)
      if (Command("A6000R") == false)
      {
        return;
      }

      // Set valve to output
      if (Command("OR") == false)
      {
        return;
      }

      // Move plunger to zero (empty syringe)
      if (Command("A0R") == false)
      {
        return;
      }

      // Wait for device to finish
      if (communicator.WaitForDevice() == Communicator.Status.READY)
      {
        logger.Info("Wash ready");
      }
    }
  }
}
