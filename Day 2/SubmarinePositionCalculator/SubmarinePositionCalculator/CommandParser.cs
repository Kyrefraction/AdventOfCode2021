namespace SubmarinePositionCalculator
{
    public static class CommandParser
    {
        public static List<Command> Parse(List<string> rows)
        {
            return rows.Select(ParseRow).ToList();
        }

        private static Command ParseRow(string row)
        {
            const string delimiter = " ";
            var splitRow = row.Split(delimiter);

            if (!Enum.TryParse<Direction>(splitRow.First(), true, out var direction) || !int.TryParse(splitRow.Last(), out var amount))
                throw new FormatException($"{row} could not be parsed into direction and movement amount");

            return new Command(direction, amount);
        }
    }
}
