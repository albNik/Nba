using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Entities
{
   [DataContract]
   public class Leader
   {
      [DataMember(EmitDefaultValue = false)]
      public string Gold { get; set; }

      [DataMember(EmitDefaultValue = false)]
      public string Silver { get; set; }

      [DataMember(EmitDefaultValue = false)]
      public string Bronze { get; set; }

      [DataMember]
      public double PPG { get; set; }
   }
}
