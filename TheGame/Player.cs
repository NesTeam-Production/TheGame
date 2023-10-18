using System.Text.Json.Serialization;
using TheGame.Items;
using TheGame.Races;

namespace TheGame
{
    public class Player
    {
        private Race _race;

        private Class _class;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }

        public Race Race
        {
            get { return _race; }
            set { SetRace(value); }
        }

        public Class Class
        {
            get { return _class; }
            set { SetClass(value); }
        }

        public int MaxHP { get; private set; }
        public int ArmorClass { get; private set; }
        public int ProficencyBonus { get; private set; }

        [JsonIgnore]
        public int CurrentHP { get; private set; }

        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        public Dictionary<string, int> SkillsProficencies { get; private set; } = new Dictionary<string, int>();
        public List<string> ToolsProficencies { get; private set; } = new();

        [JsonIgnore]
        public int STRModifier { get; private set; }

        [JsonIgnore]
        public int DEXModifier { get; private set; }

        [JsonIgnore]
        public int CONModifier { get; private set; }

        [JsonIgnore]
        public int INTModifier { get; private set; }

        [JsonIgnore]
        public int WISModifier { get; private set; }

        [JsonIgnore]
        public int CHAModifier { get; private set; }

        [JsonIgnore]
        public Item? Holding { get; private set; }

        public List<Weapon> Weapons { get; private set; } = new();
        public Armor Armor { get; private set; }

        public List<Item> Inventory { get; private set; } = new List<Item>();
        public string Backstory { get; private set; } = "";

        public static Player CreateRandom(string name)
        {
            var player = new Player(name)
            {
                Strength = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Intelligence = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Dexterity = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Constitution = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Wisdom = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Charisma = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Class = Class.GetRandomClass(),
                Race = Race.GetRandomRace()
            };

            player.STRModifier = Calculator.CalculateModifier(player.Strength);
            player.INTModifier = Calculator.CalculateModifier(player.Intelligence);
            player.DEXModifier = Calculator.CalculateModifier(player.Dexterity);
            player.CONModifier = Calculator.CalculateModifier(player.Constitution);
            player.WISModifier = Calculator.CalculateModifier(player.Wisdom);
            player.CHAModifier = Calculator.CalculateModifier(player.Charisma);

            player.MaxHP = Calculator.CalculateMaxHP(player);
            player.CurrentHP = player.MaxHP;

            return player;
        }

        private void SetRace(Race race)
        {
            _race = race;
        }

        private void SetClass(Class value)
        {
            _class = value;
        }

        public override string ToString()
        {
            return $"{Name} the level {Level} {Race} {Class}: STR:{Strength}, INT:{Intelligence}, DEX:{Dexterity}, CON:{Constitution}, WIS:{Wisdom}, CHA:{Charisma} | MaxHP:{MaxHP}";
        }

        public void AttackWithWeapon(Player enemy)
        {
            if (Holding is Weapon weapon)
            {
                var damage = weapon.RollDamage();
                Console.WriteLine($"{Name} dealt {damage} damage to {enemy.Name}.");
                enemy.CurrentHP -= damage;
            }
        }

        public void PickUp(Weapon weapon)
        {
            Holding = weapon;
            Inventory.Add(weapon);
        }
    }
}