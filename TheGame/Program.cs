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

            Logger.LogList(players);
            Logger.LogBestStats(players);

            // Generate dummy weapons
            List<Weapon> weapons = WeaponFactory.GenerateWeapons();
            WeaponFactory.ZipWeapons();

            var task = Task.Run(async () =>
            {
                try
                {
                    await StartAsync(players).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            });
            task.GetAwaiter().GetResult();
        }

        private static async Task StartAsync(List<Player> players)
        {
            // Generate battle options
            var player1 = players[rnd.Next(players.Count)];
            var player2 = players.Except(new List<Player>() { player1 }).ToArray()[rnd.Next(players.Count() - 1)];

            DuelArena arena = new(player1, player2);
            var results = await arena.DuelAsync();
        }
    }
}