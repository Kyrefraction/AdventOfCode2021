namespace SubmarineConsumptionCalculatorService
{
    public static class BitPositionValueParser
    {
        public static Dictionary<int, List<string>> GetColumnValues(List<string> values)
        {
            var valuesDictionary = new Dictionary<int, List<string>>();
            const int rowLength = 12;

            foreach (var column in values)
            {
                for (int i = 0; i < rowLength; i++)
                {
                    if (valuesDictionary.TryGetValue(i, out var listOfValues))
                    {
                        listOfValues.Add(GetColumnValue(column, i));
                    }
                    else
                    {
                        valuesDictionary.Add(i, new List<string> { GetColumnValue(column, i) });
                    }
                }
            }

            return valuesDictionary;
        }

        private static string GetColumnValue(string value, int columnPosition)
        {
            return $"{value[columnPosition]}";
        }
    }
}
