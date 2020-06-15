using System.Xml.Linq;

namespace Fluiid.Source.Utility
{
  /// <summary>
  /// XML Processor
  /// </summary>
  class XMLProcessor
  {
    /// <summary>
    /// Read XML file
    /// </summary>
    /// <param name="path">File path</param>
    /// <returns>XML</returns>
    public static XElement Read(string path)
    {
      if (System.IO.File.Exists(path))
      {
        return XElement.Load(path);
      }
      
        return null;
    }

    /// <summary>
    /// Write XML to file
    /// </summary>
    /// <param name="xml">XML to write</param>
    /// <param name="path">File path</param>
    public static void Write(XElement xml, string path)
    {
      xml.Save(path);
    }
  }
}
