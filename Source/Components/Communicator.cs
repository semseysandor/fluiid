using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluiid_cs.Source.Components
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

    public struct Port
    {
      public const int baudRate = 38400;
      public const Parity parity = Parity.None;
      public const int dataBits = 8;
      public const StopBits stopBits = StopBits.One;
    }


    private string portName;

    private SerialPort port;
    private Logger.LoggerInterface logger;

    private static string name { get; set; } = "Communicator";

    public event ConnectedEventHandler Connected;

    public delegate void ConnectedEventHandler();

    public event DisconnectedEventHandler Disconnected;

    public delegate void DisconnectedEventHandler();

    public event ConnectionLostEventHandler ConnectionLost;

    public delegate void ConnectionLostEventHandler();

    

    /// <summary>
    /// Ready status
    /// </summary>
    public const string STATUS_READY = "READY";

    /// <summary>
    /// Busy status
    /// </summary>
    public const string STATUS_BUSY = "BUSY";

    /// <summary>
    /// Error status
    /// </summary>
    public const string STATUS_ERROR = "ERROR";


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="port">Serial port name</param>
    /// <param name="logger">Logger</param>
    public Communicator(string port, ref Logger.LoggerInterface logger)
    {
      portName = port;
      this.logger = logger;
    }

    public bool Boot()
    {
      port = new SerialPort(portName, Port.baudRate, Port.parity, Port.dataBits, Port.stopBits);
    }


    /// <summary>
    /// Opens the serial port
    /// </summary>
    public void Connect()
    {
      try
      {
        port.Open();
        if (port.IsOpen == true)
        {
          Connected?.Invoke();
        }
      }
      catch (UnauthorizedAccessException ex)
      {
        iSpit.ErrorHandling.Critical(ref logger, "Access is denied to the port.", name);
      }
      catch (ArgumentException ex)
      {
        iSpit.ErrorHandling.Critical(ref logger, @"The port name does not begin with 'COM'. - or -The file type of the port is not
    '     supported.", name);
      }
      catch (System.IO.IOException ex)
      {
        iSpit.ErrorHandling.Critical(ref logger, "The port is in an invalid state.", name);
      }
      catch (InvalidOperationException ex)
      {
        iSpit.ErrorHandling.Critical(ref logger, "The specified port is already open.", name);
      }
      catch (Exception ex)
      {
        iSpit.ErrorHandling.Critical(ref logger, ex.Message, name);
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
      catch (System.IO.IOException ex)
      {
        logger.Critical("The port is in an invalid state.", name);
      }
      catch (Exception ex)
      {
        logger.Critical(ex.Message, name);
      }
    }


    /// <summary>
    /// Send a command to the device
    /// </summary>
    /// <param name="command"></param>
    public bool Send(string command)
    {
      try
      {
        port.Write(COMMAND_START_CHAR + DEVICE_ADDR + command + Constants.vbCr);
        logger.Internal("S: " + command);
        Thread.Sleep(ResponseTime);
        return true;
      }
      catch (InvalidOperationException ex)
      {
        ConnectionLost?.Invoke();
        logger.Critical("The port is not open.", name);
        return false;
      }
      catch (Exception ex)
      {
        logger.Critical(ex.Message, name);
        return false;
      }
    }
    /// <summary>
    /// Reads answer from the input buffer
    /// </summary>
    /// <returns>The answer string</returns>
    public string Read()
    {
      string answer = "";
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

          answer += Conversions.ToString((char)received);
        }

        // Remove answer start character and master address
        if (answer.Length >= 2 && Conversions.ToString(answer[0]) == "/" & Conversions.ToString(answer[1]) == "0")
        {
          answer = Strings.Mid(answer, 3);
        }

        logger.Internal("R: " + answer);
        return answer;
      }
      catch (InvalidOperationException ex)
      {
        ConnectionLost?.Invoke();
        logger.Critical("The specified port is not open.", name);
        return STATUS_ERROR;
      }
      catch (TimeoutException ex)
      {
        ConnectionLost?.Invoke();
        logger.Critical("The operation did not complete before the time-out period ended.", name);
        return STATUS_ERROR;
      }
      catch (System.IO.IOException ex)
      {
        ConnectionLost?.Invoke();
        logger.Critical("The port is in an invalid state..", name);
        return STATUS_ERROR;
      }
      catch (Exception ex)
      {
        logger.Critical(ex.Message, name);
        return STATUS_ERROR;
      }
    }
    /// <summary>
    /// Checks if device is ready to accept commands
    /// </summary>
    /// <returns>
    /// True if ready
    /// False if busy
    /// </returns>
    public string IsReady()
    {
      if (Send("Q") == false)
      {
        return STATUS_ERROR;
      }

      string answer = Read();
      if (answer == "`")
      {
        logger.Internal("Device ready");
        return STATUS_READY;
      }
      else if (answer == "@")
      {
        logger.Internal("Device busy");
        return STATUS_BUSY;
      }
      else
      {
        return STATUS_ERROR;
      }
    }
    /// <summary>
    /// Check if device received command
    /// </summary>
    /// <returns>
    /// True if received
    /// False if not
    /// </returns>
    public string Ack()
    {
      string answer = Read();
      if (answer == "@")
      {
        logger.Internal("CMD received");
        return STATUS_BUSY;
      }
      else if (answer == "`")
      {
        return STATUS_READY;
      }
      else
      {
        return STATUS_ERROR;
      }
    }
    /// <summary>
    /// Suspends script until device is ready
    /// </summary>
    public string WaitForDevice()
    {
      string device;
      do
      {
        device = IsReady();
        if ((device ?? "") == STATUS_READY)
        {
          return STATUS_READY;
        }
        else if ((device ?? "") == STATUS_ERROR)
        {
          return STATUS_ERROR;
        }

        Thread.Sleep(800);
      }
      while (true);
    }

    public string Report(string command)
    {
      if (Send(command) == false)
      {
        return STATUS_ERROR;
      }

      string answer = Read();
      if (answer.Length >= 2)
      {
        answer = Strings.Mid(answer, 2);
        return answer;
      }
      else
      {
        return "";
      }
    }
  }
}
