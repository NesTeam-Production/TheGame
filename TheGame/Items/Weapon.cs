namespace TheGame.Items
{
    public class Weapon : Item
    {
        public Weapon(int id, string name, int diceAmount, Dice damageDice, string description = "") : base(id, name, description)
        {
            DamageDice = damageDice;
            DiceAmount = diceAmount;
        }

        public Dice DamageDice { get; private set; }
        public int DiceAmount { get; private set; }

        public int RollDamage()
        {
            return Dices.Roll(DiceAmount, DamageDice);
        }
    }
}