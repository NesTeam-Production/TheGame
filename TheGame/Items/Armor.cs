using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Items
{
    public class Armor : Item
    {
        public Armor(int id, string name, int armorClass, string description = "") : base(id, name, description)
        {
            ArmorClass = armorClass;
        }

        public int ArmorClass { get; private set; }
    }
}