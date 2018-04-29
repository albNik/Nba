using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Entities
{

   public class Player
   {
      public int Id { get; set; }
      public string Position { get; set; }
      public int Number { get; set; }
      public string Country { get; set; }
      public string Name { get; set; }
      public string Height { get; set; }
      public string Weight { get; set; }
      public string University { get; set; }
      public double PPG { get; set; }
   }
}
