using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Tests
{
   [TestClass]
   public class TestDistance
   {
      [TestMethod]
      public void ParseDistance()
      {
         Distance d = Distance.FromFeet("6 ft 2 in");
         Assert.AreEqual(d.Feets, 6);
         Assert.AreEqual(d.Inches, 2);


         Assert.ThrowsException<ArgumentException>(() => { Distance.FromFeet("bad data 123"); });
      }

      [TestMethod]
      public void DistanceConversion()
      {
         Distance d = new Distance();
         Assert.AreEqual(d.Feets, 0);
         Assert.AreEqual(d.Inches, 0);

         d = new Distance(3, 5);
         Assert.AreEqual(d.Feets, 3);
         Assert.AreEqual(d.Inches, 5);

         Assert.AreEqual(d.ToCm(), 104.14, 0.001);
      }
   }
}
