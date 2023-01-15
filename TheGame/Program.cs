using TheGame.Classes;
using TheGame.Factories;
using TheGame.Items;

namespace TheGame
{
    internal class Program
    {
        public static Random rnd = new Random();

        private static void Main(string[] args)
        {
            // Genereate dummy players
            List<Player> players = new List<Player>()
            {
                Player.CreateRandom("Szpoti"),
                Player.CreateRandom("Kek"),
                Player.CreateRandom("Máté"),
                Player.CreateRandom("Balogh"),
                Player.CreateRandom("Zoli"),
                Player.CreateRandom("Kasnyik")
            };
            Logger.LogBestStats(players);

            // Generate dummy weapons
            List<Weapon> weapons = WeaponFactory.GenerateWeapons();
            WeaponFactory.ZipWeapons();
            Console.WriteLine("Weapons:");
            foreach (var weapon in weapons)
            {
                Console.WriteLine(weapon);
            }

            // Generate battle options
            var player1 = players[rnd.Next(players.Count)];
            var player2 = players.Except(new List<Player>() { player1 }).ToArray()[rnd.Next(players.Count() - 1)];
            Console.WriteLine($"Player1: {player1.Name}, Player2: {player2.Name}");
        }
    }
}