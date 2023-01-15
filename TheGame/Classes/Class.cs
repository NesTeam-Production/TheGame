using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public abstract class Class
    {
        public Class(string name, Dice hitDie)
        {
            Name = name;
            HitDie = hitDie;
        }

        public string Name { get; set; }
        public Dice HitDie { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}