namespace SubmarinePositionCalculator
{
    public class Command
    {
        public Command(Direction direction, int amount)
        {
            Direction = direction;
            Amount = amount;
        }

        public Direction Direction { get; }
        public int Amount { get; }
    }
}
