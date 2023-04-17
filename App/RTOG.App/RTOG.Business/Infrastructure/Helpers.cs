using RTOG.Business.Infrastructure.Helper;
using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Infrastructure
{
    internal class Helpers
    {
        public static string GetRandomString(int length = 25)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GetRandomHexColor()
        {
            Random random = new Random();
            string color = String.Format("#{0:X6}", random.Next(0x1000000));
            return color;
        }
        public static BattleResult DetermineOutcome(List<Unit> attackers, List<Unit> defenders)
        {
            double attackerPower = attackers.Sum(x => x.Attack * 5 + x.Health);
            double defenderPower = defenders.Sum(x => x.Defense * 5 + x.Health);

            List<Unit> remainingAttacker = attackers;
            List<Unit> remainingDefenders = defenders;

            int status;
            double Casualties;

            if (attackerPower > defenderPower)
            {
                Casualties = ((attackerPower - defenderPower) / (attackerPower + defenderPower)) * 100;
                Casualties = 100 - Casualties;
                remainingAttacker.Sort((x, y) => (x.Attack + x.Defense + x.Health).CompareTo(y.Attack + y.Defense + y.Health));
                remainingAttacker.Reverse();
                int numUnitsToRemove = (int)Math.Round(remainingAttacker.Count * Casualties / 100);
                if (numUnitsToRemove == remainingAttacker.Count)
                    numUnitsToRemove = remainingAttacker.Count - 1;
                remainingAttacker.RemoveRange(remainingAttacker.Count - numUnitsToRemove, numUnitsToRemove);
                remainingDefenders.Clear();
                status = 1;
            }
            else if (attackerPower < defenderPower)
            {
                Casualties = ((defenderPower - attackerPower) / (attackerPower + defenderPower)) * 100;
                Casualties = 100 - Casualties;
                remainingDefenders.Sort((x, y) => (x.Attack + x.Defense + x.Health).CompareTo(y.Attack + y.Defense + y.Health));
                remainingDefenders.Reverse();
                int numUnitsToRemove = (int)Math.Round(remainingDefenders.Count * Casualties / 100);
                if (numUnitsToRemove == remainingDefenders.Count)
                    numUnitsToRemove = remainingDefenders.Count - 1;
                remainingDefenders.RemoveRange(remainingDefenders.Count - numUnitsToRemove, numUnitsToRemove);
                remainingAttacker.Clear();
                status = 1;
            }
            else
            {
                Casualties = 50;
                remainingAttacker.Sort((x, y) => (x.Attack + x.Defense + x.Health).CompareTo(y.Attack + y.Defense + y.Health));
                remainingAttacker.Reverse();
                int numUnitsToRemoveA = (int)Math.Round(remainingAttacker.Count * Casualties / 100);
                remainingAttacker.Take(remainingAttacker.Count - numUnitsToRemoveA);

                remainingDefenders.Sort((x, y) => (x.Attack + x.Defense + x.Health).CompareTo(y.Attack + y.Defense + y.Health));
                remainingDefenders.Reverse();
                int numUnitsToRemoveD = (int)Math.Round(remainingDefenders.Count * Casualties / 100);
                remainingAttacker.Take(remainingDefenders.Count - numUnitsToRemoveD);

                status = 0;
            }

            return new BattleResult
            {
                RemainingUnitsAttacker = remainingAttacker,
                RemainingUnitsDeffender = remainingDefenders,
                Status = status
            };
        }
        public static Dictionary<string, Func< string, object>> Factions = new Dictionary<string, Func<string, object>>()
        {
            { "America", (name) => new AmericaFaction(name) },
            { "China", (name) => new ChineseFaction(name) },
            { "Russia", (name) => new RussiaFaction(name) },
        };
    }
}
