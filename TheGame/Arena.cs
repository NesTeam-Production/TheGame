using TheGame.Factories;
using TheGame.Items;

namespace TheGame
{
    public class DuelArena
    {
        public DuelArena(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;

            CurrentPlayer = player1;
        }

        public Guid Id { get; set; } = new();
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int Round { get; set; } = 0;
        public Player CurrentPlayer { get; set; }

        public async Task<ArenaResult> DuelAsync()
        {
            Console.WriteLine($"Player1: {Player1.Name}, Player2: {Player2.Name}");
            var weapon = WeaponFactory.GetRandomWeapon();
            Console.WriteLine($"Choosen weapon: {weapon}");
            Player1.PickUp(weapon);
            Player2.PickUp(weapon);

            await Task.Run(() =>
            {
                FightUntilDeath();
            });

            Player winner = Player1.CurrentHP >= 0 ? Player1 : Player2;
            Player looser = Player1.CurrentHP >= 0 ? Player2 : Player1;

            ArenaResult result = new(Winner: winner, Loser: looser);
            return result;
        }

        private void FightUntilDeath()
        {
            while (Player1.CurrentHP >= 0 && Player2.CurrentHP >= 0)
            {
                DisplayRoundState();
                Task.Delay(1000).Wait();
                Player1.AttackWithWeapon(Player2);
                if (Player2.CurrentHP <= 0)
                {
                    break;
                }
                Player2.AttackWithWeapon(Player1);
            }
        }

        private void DisplayRoundState()
        {
            Round++;
            Console.WriteLine($"~~~~ Round {Round} ~~~~");
        }

        public record ArenaResult(Player Winner, Player Loser);
    }
}