using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluiid_cs.Source.Components.Logger;

namespace Fluiid_cs.Source.Exception
{

  /// <summary>
  /// Exception Handler
  /// </summary>
  public class ExceptionHandler
  {
    private Logger logger;
    public ExceptionHandler(ref Logger logger)
    {
      this.logger = logger;
    }

    public void handleFatal()
    {

    }
  }
}
