using System;
using System.IO.Ports;
using Fluiid.Source.Exception;

namespace Fluiid.Source.Components
{
  /// <summary>
  /// Handles serial port communication
  /// </summary>
  public partial class Communicator
  {
    /// <summary>
    /// Command block start character
    /// </summary>
    public const string COMMAND_START_CHAR = "/";

    /// <summary>
    /// Device address (physical)
    /// </summary>
    public const string DEVICE_ADDR = "1";

    /// <summary>
    /// Response time to wait after sending a command in millisecond (ms)
    /// </summary>
    public const int ResponseTime = 100;

    /// <summary>
    /// Status codes
    /// </summary>
    public struct Status
    {
      public const int READY = 0;
      public const int BUSY = 1;
      public const int ERROR = 2;
    }

    /// <summary>
    /// Serial Port details
    /// </summary>
    public struct Port
    {
      public const int baudRate = 38400;
      public const Parity parity = Parity.None;
      public const int dataBits = 8;
      public const StopBits stopBits = StopBits.One;
    }

    /// <summary>
    /// Serial port name (eg. COM1)
    /// </summary>
    private string portName;

    /// <summary>
    /// Serial port
    /// </summary>
    private SerialPort port;

    /// <summary>
    /// Logger
    /// </summary>
    private Logger.Logger logger;

    public event ConnectedEventHandler Connected;

    public delegate void ConnectedEventHandler();

    public event DisconnectedEventHandler Disconnected;

    public delegate void DisconnectedEventHandler();

    public event ConnectionLostEventHandler ConnectionLost;

    public delegate void ConnectionLostEventHandler();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="port">Serial port name</param>
    /// <param name="logger">Logger</param>
    public Communicator(string port, ref Logger.Logger logger)
    {
      portName = port;
      this.logger = logger;
    }

    /// <summary>
    /// Boot communicator
    /// </summary>
    public void Boot()
    {
      port = new SerialPort(portName, Port.baudRate, Port.parity, Port.dataBits, Port.stopBits);
    }

    /// <summary>
    /// Open the serial port
    /// </summary>
    public void Connect()
    {
      try
      {
        port.Open();
        if (port.IsOpen == true)
        {
          Connected?.Invoke();
        } else
        {
          Disconnected?.Invoke();
        }
      }
      catch (System.Exception ex)
      {
        throw new CommunicationException("Port opening failed. Please check port name.", ex);
      }
    }

    /// <summary>
    /// Closes the serial port
    /// </summary>
    public void Close()
    {
      if (port.IsOpen == false)
      {
        Disconnected?.Invoke();
        return;
      }

      try
      {
        port.Close();
        if (port.IsOpen == false)
        {
          Disconnected?.Invoke();
        }
      }
      catch (System.Exception ex)
      {
        throw new CommunicationException("Port closing failed.", ex);
      }
    }

    /// <summary>
    /// Send a command to the device
    /// </summary>
    /// <param name="command">Command to send</param>
    public bool Send(string command)
    {
      try
      {
        port.Write(COMMAND_START_CHAR + DEVICE_ADDR + command + Environment.NewLine);
        logger.Debug("S: " + command);
        System.Threading.Thread.Sleep(ResponseTime);
        return true;
      }
      catch (System.Exception ex)
      {
        ConnectionLost?.Invoke();
        throw new CommunicationException("Can not send command to device.", ex);
      }
    }

    /// <summary>
    /// Reads answer from the input buffer
    /// </summary>
    /// <returns>The answer string</returns>
    public string Read()
    {
      // Answer string
      string answer = "";

      // Received character
      int received;
      try
      {
        while (port.BytesToRead > 0)
        {
          received = port.ReadByte();

          // If not ASCII received
          if (received > 127)
          {
            continue;
          }

          // If received 'ETX" character (end of answer block)
          if (received == 3)
          {
            port.DiscardInBuffer();
            break;
          }

          answer += (char)received;
        }

        // Remove answer start character and master address
        if (answer.Length >= 2 && answer[0].ToString() == "/" && answer[1].ToString() == "0")
        {
          answer=answer.Substring(2);
        }

        logger.Debug("R: " + answer);
        return answer;
      }
      catch (System.Exception ex)
      {
        ConnectionLost?.Invoke();
        throw new CommunicationException("Can not read from device", ex);
      }
    }

    /// <summary>
    /// Checks if device is ready to accept commands
    /// </summary>
    /// <returns>Status code</returns>
    public int IsReady()
    {
      // Send query command
      if (Send("Q") == false)
      {
        // Sending failed --> Error
        return Status.ERROR;
      }

      // Read answer from device
      string answer = Read();

      // Parse answer
      switch (answer)
      {
        case "`":
          logger.Debug("Device ready");
          return Status.READY;
        case "@":
          logger.Debug("Device busy");
          return Status.BUSY;
        default:
          return Status.ERROR;
      }
    }

    /// <summary>
    /// Check if device received command
    /// </summary>
    /// <returns>Status code</returns>
    public int Ack()
    {
      // Read answer
      string answer = Read();

      // Parse answer
      switch (answer)
      {
        case "`":
          return Status.READY;
        case "@":
          logger.Debug("CMD received");
          return Status.BUSY;
        default:
          return Status.ERROR;
      }
    }

    /// <summary>
    /// Suspends script until device is ready
    /// </summary>
    public int WaitForDevice()
    {
      int status;
      do
      {
        // Check status
        status = IsReady();

        // Device not busy --> return status
        if (status == Status.READY || status==Status.ERROR)
        {
          return status;
        }

        // Device busy --> wait and ask again
        System.Threading.Thread.Sleep(800);
      }
      while (true);
    }

    /// <summary>
    /// Send a report command
    /// </summary>
    /// <param name="command">Report command</param>
    /// <returns>Answer from device</returns>
    public string Report(string command)
    {
      // Send command
      if (Send(command) == false)
      {
        return "Error";
      }

      // Read answer
      string answer = Read();

      // Remove answer start character and master address
      if (answer.Length >= 2 && answer[0].ToString() == "/" && answer[1].ToString() == "0")
      {
        return answer.Substring(2);
      }

      // Not recognized answer
      return "";
    }
  }
}
