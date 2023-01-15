using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Classes
{
    internal class Fighter : Class
    {
        public Fighter() : base(nameof(Fighter), Dice.d10)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}