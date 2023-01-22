using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TheGame
{
    public static class Calculator
    {
        public static int CalculateMaxHP(Player player)
        {
            if (player.Class == null)
            {
                throw new ArgumentNullException($"Class was not set to calculate MaxHP of {player.Name}.");
            }
            if (player.Level == 1)
            {
                return (int)player.Class.HitDie + player.CONModifier;
            }
            return Dices.Roll(player.Level, player.Class.HitDie) + player.Level * player.CONModifier;
        }

        public static int CalculateModifier(int ability)
        {
            return (int)(Math.Floor((ability - 10) / 2.0));
        }
    }
}