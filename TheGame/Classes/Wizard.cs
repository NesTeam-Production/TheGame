using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Classes
{
    internal class Wizard : Class
    {
        public Wizard() : base(nameof(Wizard))
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}