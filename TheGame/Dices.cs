using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public static class Dices
    {
        private static readonly Random rnd = new Random();

        public static List<int> RollAbility(int rolls)
        {
            var dices = new List<int>();
            for (int i = 0; i < rolls; i++)
            {
                var num = rnd.Next(1, 7);
                dices.Add(num);
            }
            return dices;
        }

        public static void ShowResult(List<int> dices)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(dices.First().ToString());
            foreach (var d in dices.Skip(1))
            {
                sb.Append("," + d.ToString());
            }
            Console.WriteLine(sb.ToString());
        }

        internal static int Roll(int diceAmount, Dice die)
        {
            return Enumerable.Repeat(rnd.Next(1, (int)die + 1), diceAmount).Sum();
        }
    }

    public enum Dice
    {
        d4 = 4,
        d6 = 6,
        d8 = 8,
        d10 = 10,
        d12 = 12,
        d20 = 20,
        d100 = 100
    }
}