using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Entities
{
   [DataContract]
   public class Report
   {
      [DataMember(Order = 1)]
      public Player[] Players { get; set; }

      [DataMember(Order = 2)]
      public double AveragePPG { get; set; }

      [DataMember(Order = 3)]
      public Leader[] Leaders { get; set; }

      [DataMember(Order = 4)]
      public Dictionary<string, int> Positions { get; set; }

      [DataMember(Order = 5)]
      public double AverageHeight { get; set; }
   }
}
