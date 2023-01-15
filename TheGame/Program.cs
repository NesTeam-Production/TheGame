using TheGame.Classes;
using TheGame.Factories;
using TheGame.Items;

namespace TheGame
{
    internal class Program
    {
        public Random rnd = new Random();

        private static void Main(string[] args)
        {
            List<Player> players = new List<Player>()
            {
                Player.CreateRandom("Szpoti"),
                Player.CreateRandom("Kek"),
                Player.CreateRandom("Máté"),
                Player.CreateRandom("Balogh"),
                Player.CreateRandom("Zoli"),
                Player.CreateRandom("Kasnyik")
            };
            List<Weapon> weapons = WeaponFactory.GenerateWeapons();
            WeaponFactory.ZipWeapons();

            Console.WriteLine("Weapons:");
            foreach (var weapon in weapons)
            {
                Console.WriteLine(weapon);
            }

            Logger.LogBestStats(players);
        }
    }
}