using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TheGame
{
    public static class Logger
    {
        public static void LogRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void LogBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void LogGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void LogDarkYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void LogMagenta(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void LogCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void LogError(Exception exc)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exc);
            Console.ResetColor();
        }

        public static void LogBestStats(List<Player> players)
        {
            var bestSTR = players.Select(p => p.Strength).Max();
            var bestSTRplayers = players.Where(p => p.Strength == bestSTR);

            var bestINT = players.Select(p => p.Intelligence).Max();
            var bestINTplayers = players.Where(p => p.Intelligence == bestINT);

            var bestDEX = players.Select(p => p.Dexterity).Max();
            var bestDEXplayers = players.Where(p => p.Dexterity == bestDEX);

            var bestCON = players.Select(p => p.Constitution).Max();
            var bestCONplayers = players.Where(p => p.Constitution == bestCON);

            var bestWIS = players.Select(p => p.Wisdom).Max();
            var bestWISplayers = players.Where(p => p.Wisdom == bestWIS);

            var bestCHA = players.Select(p => p.Charisma).Max();
            var bestCHAplayers = players.Where(p => p.Charisma == bestCHA);

            if (bestSTRplayers.Count() == 1)
            {
                LogRed($"Best STR player: {bestSTRplayers.Single().Name} with {bestSTR}.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Best STR players are: {bestSTRplayers.First().Name}");
                foreach (var player in bestSTRplayers.Skip(1))
                {
                    sb.Append(", " + player.Name);
                }
                sb.Append($" with {bestSTR}.");

                LogRed(sb.ToString());
            }

            Console.WriteLine();
            if (bestDEXplayers.Count() == 1)
            {
                LogGreen($"Best DEX player: {bestDEXplayers.Single().Name} with {bestDEX}.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Best DEX players are: {bestDEXplayers.First().Name}");
                foreach (var player in bestDEXplayers.Skip(1))
                {
                    sb.Append(", " + player.Name);
                }
                sb.Append($" with {bestDEX}.");

                LogGreen(sb.ToString());
            }

            Console.WriteLine();
            if (bestCONplayers.Count() == 1)
            {
                LogMagenta($"Best CON player: {bestCONplayers.Single().Name} with {bestCON}.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Best CON players are: {bestCONplayers.First().Name}");
                foreach (var player in bestCONplayers.Skip(1))
                {
                    sb.Append(", " + player.Name);
                }
                sb.Append($" with {bestCON}.");

                LogMagenta(sb.ToString());
            }
            Console.WriteLine();
            if (bestINTplayers.Count() == 1)
            {
                LogBlue($"Best INT player: {bestINTplayers.Single().Name} with {bestINT}.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Best INT players are: {bestINTplayers.First().Name}");
                foreach (var player in bestINTplayers.Skip(1))
                {
                    sb.Append(", " + player.Name);
                }
                sb.Append($" with {bestINT}.");

                LogBlue(sb.ToString());
            }

            Console.WriteLine();
            if (bestWISplayers.Count() == 1)
            {
                LogCyan($"Best WIS player: {bestWISplayers.Single().Name} with {bestWIS}.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Best WIS players are: {bestWISplayers.First().Name}");
                foreach (var player in bestWISplayers.Skip(1))
                {
                    sb.Append(", " + player.Name);
                }
                sb.Append($" with {bestWIS}.");

                LogCyan(sb.ToString());
            }

            Console.WriteLine();
            if (bestCHAplayers.Count() == 1)
            {
                LogDarkYellow($"Best CHA player: {bestCHAplayers.Single().Name} with {bestCHA}.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Best CHA players are: {bestCHAplayers.First().Name}");
                foreach (var player in bestCHAplayers.Skip(1))
                {
                    sb.Append(", " + player.Name);
                }
                sb.Append($" with {bestCHA}.");

                LogDarkYellow(sb.ToString());
            }
        }

        public static void LogBIG()
        {
            Console.WriteLine("\n\n\n\n\n\n");
        }

        internal static void LogList<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}