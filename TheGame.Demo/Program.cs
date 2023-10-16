using TheGame.Factories;
using TheGame.Items;

namespace TheGame.Demo
{
    internal static class Program
    {
        private static readonly Random rnd = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            Task.Run(() => InitializeStartup());
        }

        private static void InitializeStartup()
        {
            // Genereate dummy players
            List<Player> players = new List<Player>()
            {
                Player.CreateRandom("Szpoti"),
                Player.CreateRandom("Kek"),
                Player.CreateRandom("Máté"),
                Player.CreateRandom("Balogh"),
                Player.CreateRandom("Zoli"),
                Player.CreateRandom("Kasnyik"),
                Player.CreateRandom("Gréti")
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

            Console.WriteLine($"THE WINNER IS : {results.Winner.Name} with {results.Winner.CurrentHP} HP.");
        }
    }
}