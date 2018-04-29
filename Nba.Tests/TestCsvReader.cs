using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba.Tests
{
   [TestClass]
   public class TestCsvParser
   {
      [TestMethod]
      public void ParseCsvLine()
      {
         string test = @"1,PG,10,United States,""Armstrong, B.J."",6 ft 2 in,175 lb,Iowa,12.3";

         CsvReader reader = new CsvReader();
         var player = reader.GetPlayer(test);
         Assert.AreEqual(1, player.Id);
         Assert.AreEqual("PG", player.Position);
         Assert.AreEqual(10, player.Number);
         Assert.AreEqual("United States", player.Country);
         Assert.AreEqual("Armstrong, B.J.", player.Name);
         Assert.AreEqual("6 ft 2 in", player.Height);
         Assert.AreEqual("175 lb", player.Weight);
         Assert.AreEqual("Iowa", player.University);
         Assert.AreEqual(12.3, player.PPG, 0.0001);

         var badData = @"PG,10,United States,""Armstrong,""";
         Assert.ThrowsException<CsvParserException>(() => { reader.GetPlayer(badData); });
      }


      [TestMethod]
      public void ParseCsv()
      {
         string test = @"Id,Position,Number,Country,Name,Height,Weight,University,PPG
1,PG,10,United States,""Armstrong, B.J."",6 ft 2 in,175 lb,Iowa,12.3
2,C,24,United States,""Cartwright, Bill"",7 ft 1 in,246 lb,San Francisco,5.6
3,PF,54,United States,""Grant, Horace"",6 ft 10 in,245 lb,Clemson,13.2";

         CsvReader reader = new CsvReader();
         var players = reader.Read(new StringReader(test)).ToList();
         Assert.AreEqual(3, players.Count);
         Assert.AreEqual(1, players[0].Id);
         Assert.AreEqual(2, players[1].Id);
         Assert.AreEqual(3, players[2].Id);
      }
   }
}
