using TheGame.Classes;
using TheGame.Races;

namespace TheGame.Factories
{
    public static class CharacterFactory
    {
        public static void CreateCharacter()
        {
            int level = ChooseLevel();
            Class choosenClass = ChooseClass();
            Race choosenRace = ChoosenRace();

            Task task = OpenAIHandler.GenerateFullCharacter(level, choosenClass, choosenRace);
            Console.WriteLine("Waiting for Task to finish...");
            task.Wait();
            Console.WriteLine("It's finished!");
        }

        private static int ChooseLevel()
        {
            Console.WriteLine("What level are you? (1-20)");
            var choice = Console.ReadLine();
            bool indexCorrect =
                int.TryParse(choice, out int choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= 20;
            while (!indexCorrect)
            {
                Logger.LogRed("Invalid input, try again.");
                choice = Console.ReadLine();
                indexCorrect =
                int.TryParse(choice, out choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= 20;
            }
            return choiceIndex;
        }

        private static Class ChooseClass()
        {
            var classes = Enum.GetValues(typeof(ClassList));
            Console.WriteLine("Choose your class:");
            for (int i = 1; i <= classes.Length; i++)
            {
                Console.WriteLine($"({i}) - {classes.GetValue(i - 1)}");
            }

            var choice = Console.ReadLine();
            bool indexCorrect =
                int.TryParse(choice, out int choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= classes.Length;
            while (!indexCorrect)
            {
                Logger.LogRed("Invalid input, try again.");
                choice = Console.ReadLine();
                indexCorrect =
                int.TryParse(choice, out choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= classes.Length;
            }
            var choosenClass = classes.GetValue(choiceIndex - 1);
            return choosenClass switch
            {
                ClassList.Fighter => new Fighter(),
                ClassList.Rouge => new Rouge(),
                ClassList.Wizard => new Wizard(),
                _ => throw new InvalidOperationException(),
            };
        }

        private static Race ChoosenRace()
        {
            {
                var races = Enum.GetValues(typeof(RaceList));
                Console.WriteLine("Choose your Race:");
                for (int i = 1; i <= races.Length; i++)
                {
                    Console.WriteLine($"({i}) - {races.GetValue(i - 1)}");
                }

                var choice = Console.ReadLine();
                bool indexCorrect =
                    int.TryParse(choice, out int choiceIndex)
                    && choiceIndex >= 1
                    && choiceIndex <= races.Length;
                while (!indexCorrect)
                {
                    Logger.LogRed("Invalid input, try again.");
                    choice = Console.ReadLine();
                    indexCorrect =
                    int.TryParse(choice, out choiceIndex)
                    && choiceIndex >= 1
                    && choiceIndex <= races.Length;
                }
                var choosenRace = races.GetValue(choiceIndex - 1);
                return choosenRace switch
                {
                    RaceList.Human => new Human(),
                    _ => throw new InvalidOperationException(),
                };
            }
        }
    }
}