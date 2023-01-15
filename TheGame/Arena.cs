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

            DisplayRoundState();

            ArenaResult result = new(Winner: Player1, Loser: Player2);
            return result;
        }

        private void DisplayRoundState()
        {
            Console.WriteLine($"~~ Round {Round} ~~");
        }

        public record ArenaResult(Player Winner, Player Loser);
    }
}