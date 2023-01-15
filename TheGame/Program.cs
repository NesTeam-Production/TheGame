using TheGame.Classes;
using TheGame.Items;

namespace TheGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Player> players = new List<Player>()
            {
                Player.CreateRandom("Szpoti"),
                Player.CreateRandom("Kek"),
                Player.CreateRandom("Máté"),
                Player.CreateRandom("Balogh"),
                Player.CreateRandom("Zoli"),
                Player.CreateRandom("Kasnyik")
            };
            new Weapon(1, "Knife", 1, Dice.d4, "Is very sharp...");
            Logger.LogBestStats(players);
        }
    }
}