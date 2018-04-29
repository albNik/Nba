using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Entities
{
   public class Distance
   {
      public int Feets { get; private set; }
      public int Inches { get; private set; }

      public Distance()
         : this(0, 0)
      { }

      public Distance(int feet, int inches)
      {
         Feets = feet;
         Inches = inches;
      }


      public static Distance FromFeet(string s) // 6 ft 5 in
      {
         var parts = s.Split(' ');

         if(parts.Length == 4)
         {
            int feet = 0;
            int inches = 0;
            if(parts[1] == "ft" && parts[3] == "in" && int.TryParse(parts[0], out feet) && int.TryParse(parts[2], out inches))
               return new Distance(feet, inches);
         }
         throw new ArgumentException("format exception", s);
      }

      public double ToCm()
      {
         return (12 * Feets + Inches) * 2.54;
      }
   }
}
