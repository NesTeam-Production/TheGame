using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Classes;

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

        public static Class GetRandomClass()
        {
            Random rnd = new();
            var classes = new List<Class>()
            {
                new Fighter(),
                new Rouge(),
                new Wizard()
            };
            return classes[rnd.Next(classes.Count)];
        }
    }
}