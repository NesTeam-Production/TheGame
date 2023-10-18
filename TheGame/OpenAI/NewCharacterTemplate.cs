using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Items;
using TheGame.Races;

namespace TheGame.OpenAI
{
    internal class NewCharacterTemplate
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public string Race { get; set; }

        public string Class { get; set; }

        public int MaxHP { get; set; }
        public int ArmorClass { get; set; }
        public int ProficiencyBonus { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public Dictionary<string, int> SkillsProficiencies { get; set; }
        public List<string> ToolsProficiencies { get; set; }

        public List<string> Weapons { get; set; }
        public string Armor { get; set; }

        public List<string> Inventory { get; set; }
        public List<string> Spells { get; set; }
        public string Backstory { get; set; }
    }
}