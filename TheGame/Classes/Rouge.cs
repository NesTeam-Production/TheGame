using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Classes
{
    internal class Rouge : Class
    {
        public Rouge() : base(nameof(Rouge), Dice.d8)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}