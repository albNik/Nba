using Nba.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Nba
{
   class Program
   {
      static void Main(string[] args)
      {
         try
         {
            Player[] players = null;
            var csvReader = new CsvReader();

            string inputFile = "chicago-bulls.csv";
            Console.WriteLine($"Reading file '{inputFile}' ....");
            using(var sr = new StreamReader(inputFile))
               players = csvReader.Read(sr).ToArray();
            Console.WriteLine($" {players.Length} players");

            ReportBuilder reportBuilder = new ReportBuilder(players);
            var report = reportBuilder.GetReport();

            Console.WriteLine($"Building Report");
            var js = new DataContractJsonSerializer(typeof(Report), new DataContractJsonSerializerSettings() { UseSimpleDictionaryFormat = true });
            string outPath = "chicago-bulls.json";
            Console.Write($"Saving Report to '{outPath}'");
            using(var stream = File.Create(outPath))
               js.WriteObject(stream, report);
            Console.WriteLine("... OK");

         }

         catch(Exception ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.WriteLine("Press enter to exit");
         Console.ReadLine();


      }
   }
}
