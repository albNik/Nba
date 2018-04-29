using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Entities
{

   [DataContract]
   public class Player
   {
      [DataMember(Order = 1)]
      public int Id { get; set; }
      [DataMember(Order = 2)]
      public string Position { get; set; }
      [DataMember(Order = 3)]
      public int Number { get; set; }
      [DataMember(Order = 4)]
      public string Country { get; set; }
      [DataMember(Order = 4)]
      public string Name { get; set; }
      [DataMember(Order = 5)]
      public string Height { get; set; }
      [DataMember(Order = 6)]
      public string Weight { get; set; }
      [DataMember(Order = 7)]
      public string University { get; set; }
      [DataMember(Order = 8)]
      public double PPG { get; set; }
   }
}
