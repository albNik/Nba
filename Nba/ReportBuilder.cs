using Nba.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nba
{
   public class ReportBuilder
   {
      private IEnumerable<Player> players;

      public ReportBuilder(IEnumerable<Player> players)
      {
         this.players = players;
      }

      public Player[] GetSortedByPpg()
      {
         return players.OrderByDescending(x => x.PPG).ToArray();
      }

      public double GetAveragePpg()
      {
         if(!players.Any())
            return 0;
         return Math.Round(players.Average(x => x.PPG), 2);
      }

      public Leader[] GetLeaders()
      {
         List<Leader> leaders = new List<Leader>();
         var sorted = GetSortedByPpg();
         if(sorted.Length > 0)
            leaders.Add(new Leader
            {
               Gold = sorted[0].Name,
               PPG = sorted[0].PPG,
            });

         if(sorted.Length > 1)
            leaders.Add(new Leader
            {
               Silver = sorted[1].Name,
               PPG = sorted[1].PPG,
            });

         if(sorted.Length > 2)
            leaders.Add(new Leader
            {
               Bronze = sorted[2].Name,
               PPG = sorted[2].PPG,
            });

         return leaders.ToArray();
      }

      public Dictionary<string, int> GetPositions()
      {
         return players.GroupBy(x => x.Position)
                        .ToDictionary(x => x.Key, y => y.Count());
      }

      public double GetAverageHeight()
      {
         if(!players.Any())
            return 0;
         return Math.Round(players.Average(x => Distance.FromFeet(x.Height).ToCm()), 1);
      }

      public Report GetReport()
      {
         return new Report
         {
            Players = GetSortedByPpg(),
            AveragePPG = GetAveragePpg(),
            Leaders = GetLeaders(),
            Positions = GetPositions(),
            AverageHeight = GetAverageHeight(),
         };
      }
   }
}
