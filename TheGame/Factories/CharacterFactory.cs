using TheGame.Classes;

namespace TheGame.Factories
{
    public static class CharacterFactory
    {
        public static void CreateCharacter()
        {
            int level = ChooseLevel();
            Class choosenClass = ChooseClass();
        }

        private static int ChooseLevel()
        {
            Console.WriteLine("What level are you? (1-20)");
            var choice = Console.ReadKey().KeyChar.ToString();
            bool indexCorrect =
                int.TryParse(choice, out int choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= 20;
            while (!indexCorrect)
            {
                Logger.LogRed("Invalid input, try again.");
                choice = Console.ReadKey().KeyChar.ToString();
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

            var choice = Console.ReadKey().KeyChar.ToString();
            bool indexCorrect =
                int.TryParse(choice, out int choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= classes.Length;
            while (!indexCorrect)
            {
                Logger.LogRed("Invalid input, try again.");
                choice = Console.ReadKey().KeyChar.ToString();
                indexCorrect =
                int.TryParse(choice, out choiceIndex)
                && choiceIndex >= 1
                && choiceIndex <= classes.Length;
            }
            var choosenClass = classes.GetValue(choiceIndex);
            return choosenClass switch
            {
                ClassList.Fighter => new Fighter(),
                ClassList.Rouge => new Rouge(),
                ClassList.Wizard => new Wizard(),
                _ => throw new InvalidOperationException(),
            };
        }
    }
}