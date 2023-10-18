using TheGame.Factories;

namespace TheGame
{
    internal class Program
    {
        public static Random rnd = new Random();

        private static void Main(string[] args)
        {
            CharacterFactory.CreateCharacter();
        }
    }
}