using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Fluiid.Source.Utility;

namespace Fluiid.Source
{
  /// <summary>
  /// Configurator
  /// </summary>
  public class Configurator
  {
    /// <summary>
    /// Settings File
    /// </summary>
    public static string settingsFile = "config.xml";

    /// <summary>
    /// Actual configs
    /// </summary>
    private struct Config
    {
      public string port;
      public int logLevel;
    }

    /// <summary>
    /// Defaults and config metadata
    /// </summary>
    public struct DEF
    {
      public struct PORT
      {
        public const string name = "port";
        public const string value = "COM4";
      }
      public struct LOG
      {
        public const string name = "loglevel";
        public const int value = 2;
      }
    }

    /// <summary>
    ///  Actual Configs XML
    /// </summary>
    private XElement configXML;

    /// <summary>
    /// Actual configs
    /// </summary>
    private Config cfg;

    /// <summary>
    /// Serial Port
    /// </summary>
    public string Port
    {
      get => cfg.port;
      set
      {
        if (cfg.port != value)
        {
          cfg.port = value;
          configXML.SetElementValue(DEF.PORT.name, cfg.port);
          Save();
        }
      }
    }

    /// <summary>
    /// Logging level
    /// </summary>
    public int LogLevel
    {
      get => cfg.logLevel;
      set
      {
        if (cfg.logLevel != value)
        {
          cfg.logLevel = value;
          configXML.SetElementValue(DEF.LOG.name, cfg.logLevel);
        }
      }
    }

    /// <summary>
    /// Class constructor
    /// </summary>
    public Configurator()
    {
    }

    /// <summary>
    /// Boot Component
    /// </summary>
    public void Init()
    {
      // Load config file
      configXML = XMLProcessor.Read(settingsFile);

      // If no file found --> create
      if (configXML is null)
      {
        configXML = new XElement("config");
      }

      // Load configs
      cfg.port = LoadConfigString(DEF.PORT.name, DEF.PORT.value);
      cfg.logLevel = LoadConfigInt(DEF.LOG.name, DEF.LOG.value);
    }

    /// <summary>
    /// Load string config
    /// </summary>
    /// <param name="name">Config name</param>
    /// <param name="defaultValue">Default value</param>
    /// <returns>Config value</returns>
    protected int LoadConfigInt(string name, int defaultValue)
    {
      // Get elements with name
      IEnumerable<XElement> elements = configXML.Elements(name);
      if (elements.Any())
      {
        // Get last value (if more than one element with same name)
        if (int.TryParse(elements.Last().Value, out int config))
        {
          return config;
        }
      }

      // No config value found in file --> return default
      return defaultValue;
    }

    /// <summary>
    /// Load int config
    /// </summary>
    /// <param name="name">Config name</param>
    /// <param name="defaultValue">Default value</param>
    /// <returns></returns>
    protected string LoadConfigString(string name, string defaultValue)
    {
      // Get elements with name
      IEnumerable<XElement> elements = configXML.Elements(name);
      if (elements.Any())
      {
        // Get last value (if more than one element with same name)
        return elements.Last().Value;
      }

      // No config value found in file --> return default
      return defaultValue;
    }

    /// <summary>
    /// Save configs to file
    /// </summary>
    public void Save()
    {
      XMLProcessor.Write(configXML, settingsFile);
    }
  }
}
