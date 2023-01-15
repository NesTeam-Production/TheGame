namespace TheGame
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public int Level { get; set; }
        public string Name { get; set; }
        public Class? Class { get; set; }
        public int STR { get; set; }
        public int INT { get; set; }
        public int DEX { get; set; }
        public int CON { get; set; }
        public int WIS { get; set; }
        public int CHA { get; set; }
        public List<Item> Inventory { get; set; } = new List<Item>();

        internal static Player CreateRandom(string name)
        {
            var player = new Player(name)
            {
                STR = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                INT = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                DEX = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                CON = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                WIS = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum(),
                CHA = Dices.RollAbility(4).OrderByDescending(x => x).Take(3).Sum()
            };
            return player;
        }

        public override string ToString()
        {
            return $"{Name}: STR:{STR}, INT:{INT}, DEX:{DEX}, CON:{CON}, WIS:{WIS}, CHA:{CHA}";
        }
    }
}