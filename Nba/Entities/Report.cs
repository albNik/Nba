using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Entities
{
  public class Report
   {
      public Player[] Players { get; set; }
      public double AveragePPG { get; set; }
      public Leader[] Leaders { get; set; }
      public Dictionary<string, int> Positions { get; set; }
      public double AverageHeight { get; set; }
   }
}
