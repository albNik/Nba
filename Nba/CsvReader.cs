using Nba.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nba
{
   public class CsvReader
   {
      Regex playerRegEx = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

      public IEnumerable<Player> Read(TextReader reader)
      {
         string line = null;
         reader.ReadLine();  //ignore first line

         while((line = reader.ReadLine()) != null)
         {
            var player = GetPlayer(line);
            yield return player;
         }
      }

      public Player GetPlayer(string line)
      {
         if(string.IsNullOrWhiteSpace(line))
            throw new ArgumentException("Cannot parse emply text", "line");


         var fields = playerRegEx.Split(line);
         try
         {
            return new Player
            {
               Id = int.Parse(fields[0]),
               Position = fields[1],
               Number = int.Parse(fields[2]),
               Country = fields[3],
               Name = fields[4].Replace("\"", ""),
               Height = fields[5],
               Weight = fields[6],
               University = fields[7],
               PPG = double.Parse(fields[8], CultureInfo.InvariantCulture),
            };
         }
         catch(Exception ex)
         {
            throw new CsvParserException($"Cannot parse the text: '{line}'");
         }
      }

   }
}
