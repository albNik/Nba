using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba
{
   public class CsvParserException : Exception
   {
      public CsvParserException(string message) : base(message)
      {

      }
   }
}
