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
        public static Dictionary<string, Func< string, object>> Factions = new Dictionary<string, Func<string, object>>()
        {
            { "America", (name) => new AmericaFaction(name) },
            { "China", (name) => new ChineseFaction(name) },
            { "Russia", (name) => new RussiaFaction(name) },
        };
        public static Dictionary<string, Func<string, object>> Units = new Dictionary<string, Func<string, object>>()
        {
            { "America", (name) => new AmericaFaction(name) },
            { "China", (name) => new ChineseFaction(name) },
            { "Russia", (name) => new RussiaFaction(name) },
        };
    }
}
