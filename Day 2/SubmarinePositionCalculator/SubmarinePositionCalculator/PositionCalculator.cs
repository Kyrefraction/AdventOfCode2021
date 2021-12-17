namespace SubmarinePositionCalculator
{
    public static class PositionCalculator
    {
        public static int CalculateDisplacementArea(List<Command> commands)
        {
            var horizontalDisplacement = CalculateHorizontalDisplacement(commands);
            var verticalDisplacement = CalculateVerticalDisplacement(commands);
            return horizontalDisplacement * verticalDisplacement;
        }

        private static int CalculateVerticalDisplacement(List<Command> commands)
        {
            var lift = GetDirectionalDisplacement(commands, Direction.Up);
            var dive = GetDirectionalDisplacement(commands, Direction.Down);
            return dive - lift;
        }

        private static int CalculateHorizontalDisplacement(List<Command> commands)
        {
            var forwardDisplacement = GetDirectionalDisplacement(commands, Direction.Forward);
            return forwardDisplacement;
        }

        private static int GetDirectionalDisplacement(List<Command> commands, Direction direction)
        {
            return commands.Where(command => command.Direction == direction).Sum(command => command.Amount);
        }
    }
}
