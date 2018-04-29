using Nba.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba
{
   class Program
   {
      static void Main(string[] args)
      {

         Player[] players = null;
         var csvReader = new CsvReader();
         using(var sr = new StreamReader("chicago-bulls.csv"))
            players = csvReader.Read(sr).ToArray();



      }
   }
}
