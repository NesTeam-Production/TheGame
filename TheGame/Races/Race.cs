namespace TheGame.Races
{
    public abstract class Race
    {
        public Race(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public static Race GetRandomRace()
        {
            throw new NotImplementedException();
        }
    }
    public enum RaceList
    {
        Human
    }
}