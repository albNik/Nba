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
   public class TestReportBuilder
   {
      [TestMethod]
      public void GetReportData()
      {

         var players = new Player[]
         {
            new Player{ Name ="name 1", Position ="A", Height ="6 ft 3 in", PPG=12.5},
            new Player{ Name ="name 2", Position ="A", Height ="6 ft 4 in", PPG=8.5},
            new Player{ Name ="name 3", Position ="B", Height ="6 ft 5 in", PPG=9},
            new Player{ Name ="name 4", Position ="B", Height ="6 ft 6 in", PPG=10.5},
            new Player{ Name ="name 5", Position ="B", Height ="6 ft 7 in", PPG=11.5},
            new Player{ Name ="name 6", Position ="C", Height ="6 ft 8 in", PPG=5.5},
            new Player{ Name ="name 7", Position ="D", Height ="6 ft 9 in", PPG=2.5},
            new Player{ Name ="name 8", Position ="D", Height ="6 ft 10 in", PPG=6},
         };


         ReportBuilder reportBuilder = new ReportBuilder(players);
         var rep = reportBuilder.GetReport();
         Assert.AreEqual(rep.Players[0].Name , "name 1");
         Assert.AreEqual(rep.Players[1].Name , "name 5");
         Assert.AreEqual(rep.AveragePPG , players.Average(x=>x.PPG), 0.001);
         Assert.AreEqual(rep.Leaders[0].PPG ,12.5, 0.001);
         Assert.AreEqual(rep.Leaders[1].Silver , "name 5");
         Assert.AreEqual(rep.Positions["A"] , 2);
      }
   }
}
