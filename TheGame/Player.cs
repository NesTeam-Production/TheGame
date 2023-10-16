using TheGame.Items;
using TheGame.Races;

namespace TheGame
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public int Level { get; private set; } = 1;
        public string Name { get; private set; }

        public Race Race
        {
            get { return Race; }
            set { SetRace(value); }
        }

        public Class Class
        {
            get { return Class; }
            set { SetClass(value); }
        }

        public int MaxHP { get; private set; }
        public int CurrentHP { get; private set; }

        public int STR { get; private set; }
        public int STRModifier { get; private set; }
        public int INT { get; private set; }
        public int INTModifier { get; private set; }
        public int DEX { get; private set; }
        public int DEXModifier { get; private set; }
        public int CON { get; private set; }
        public int CONModifier { get; private set; }
        public int WIS { get; private set; }
        public int WISModifier { get; private set; }
        public int CHA { get; private set; }
        public int CHAModifier { get; private set; }
        public Item? Holding { get; private set; }
        public List<Item> Inventory { get; private set; } = new List<Item>();

        public static Player CreateRandom(string name)
        {
            var player = new Player(name)
            {
                STR = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                INT = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                DEX = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                CON = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                WIS = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                CHA = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                Class = Class.GetRandomClass(),
                Race = Race.GetRandomRace()
            };

            player.STRModifier = Calculator.CalculateModifier(player.STR);
            player.INTModifier = Calculator.CalculateModifier(player.INT);
            player.DEXModifier = Calculator.CalculateModifier(player.DEX);
            player.CONModifier = Calculator.CalculateModifier(player.CON);
            player.WISModifier = Calculator.CalculateModifier(player.WIS);
            player.CHAModifier = Calculator.CalculateModifier(player.CHA);

            player.MaxHP = Calculator.CalculateMaxHP(player);
            player.CurrentHP = player.MaxHP;

            return player;
        }

        private void SetRace(Race race)
        {
            Race = race;
        }

        private void SetClass(Class value)
        {
            Class = value;
        }

        public override string ToString()
        {
            return $"{Name} the {Class}: STR:{STR}, INT:{INT}, DEX:{DEX}, CON:{CON}, WIS:{WIS}, CHA:{CHA} | MaxHP:{MaxHP}";
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