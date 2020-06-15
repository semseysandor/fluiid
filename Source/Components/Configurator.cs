using Fluiid.Source.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
    public const string settingsFile = "config.xml";

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
        public const string value = "COM 4";
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
    /// Application
    /// </summary>
    private App app;

    /// <summary>
    /// Serial Port
    /// </summary>
    public string Port
    { 
      get => cfg.port;
      set {
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
    /// <param name="application"></param>
    public Configurator(App application)
    {
      app = application;
    }

    /// <summary>
    /// Boot Component
    /// </summary>
    public void Boot()
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
    /// <returns></returns>
    protected int LoadConfigInt(string name, int defaultValue)
    {
      IEnumerable<XElement> elements = configXML.Elements(name);
      if (elements.Any())
      {
        if (int.TryParse(elements.Last().Value, out int config)) {
          return config;
        }
      }

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
      IEnumerable<XElement> elements = configXML.Elements(name);
      if (elements.Any())
      {
        return elements.Last().Value;
      }

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
