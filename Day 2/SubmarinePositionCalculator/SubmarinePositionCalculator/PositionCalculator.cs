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

        public static int CalculateAimedDisplacementArea(List<Command> commands)
        {
            var aim = 0;
            var horizontalDisplacement = 0;
            var verticalDisplacement = 0;

            foreach (var command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.Up:
                        aim -= command.Amount;
                        break;
                    case Direction.Down:
                        aim += command.Amount;
                        break;
                    case Direction.Forward:
                        horizontalDisplacement += command.Amount;
                        verticalDisplacement += (command.Amount * aim);
                        break;
                }
            }

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
