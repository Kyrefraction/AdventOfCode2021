namespace SubmarineConsumptionCalculatorService
{
    public static class DiagnosticNumberCalculator
    {
        public static string GetOxygenGeneratorRating(Dictionary<int, List<string>> values, List<string> rows)
        {
            for (var i = 0; i < values.Count; i++)
            {
                rows = GetFilteredListByMostCommonValue(values.ElementAt(i), rows);
                values = BitPositionValueParser.GetColumnValues(rows);
            }

            return rows.First();
        }

        public static string GetCarbonDioxideScrubberRating(Dictionary<int, List<string>> values, List<string> rows)
        {
            for (var i = 0; i < values.Count; i++)
            {
                rows = GetFilteredListByLeastCommonValue(values.ElementAt(i), rows);
                values = BitPositionValueParser.GetColumnValues(rows);
            }

            return rows.First();
        }

        public static List<string> GetFilteredListByLeastCommonValue(KeyValuePair<int, List<string>> value, List<string> rows)
        {
            var leastCommonValue = GetLeastCommonValue(value.Value);
            return rows.Where(row => row[value.Key] == char.Parse(leastCommonValue)).ToList();
        }

        public static List<string> GetFilteredListByMostCommonValue(KeyValuePair<int, List<string>> value, List<string> rows)
        {
            var mostCommonValue = GetMostCommonValue(value.Value);
            return rows.Where(row => row[value.Key] == char.Parse(mostCommonValue)).ToList();
        }

        public static string GetGammaDiagnosticValue(Dictionary<int, List<string>> values)
        {
            var gamma = string.Empty;
            foreach (var value in values)
            {
                gamma += GetMostCommonValue(value.Value);
            }

            return gamma;
        }

        public static string GetEplisonDiagnosticValue(Dictionary<int, List<string>> values)
        {
            var epsilon = string.Empty;
            foreach (var value in values)
            {
                epsilon += GetLeastCommonValue(value.Value);
            }

            return epsilon;
        }

        private static string GetMostCommonValue(List<string> values)
        {
            var integerList = values.Select(int.Parse).ToList();
            return $"{GetMostCommonValue(integerList)}";
        }

        private static int GetMostCommonValue(List<int> values)
        {
            if (values.Count == 1) return values.First();

            var valuesOrderedByCount = values.GroupBy(value => value).OrderByDescending(group => group.Count());
            if (valuesOrderedByCount.First().Count() == valuesOrderedByCount.Last().Count())
                return 1;

            var groupedValues = valuesOrderedByCount.Select(group => group.Key);
            return groupedValues.First();
        }

        private static string GetLeastCommonValue(List<string> values)
        {
            var integerList = values.Select(int.Parse).ToList();
            return $"{GetLeastCommonValue(integerList)}";
        }

        private static int GetLeastCommonValue(List<int> values)
        {
            if (values.Count == 1) return values.First();

            var valuesOrderedByCount = values.GroupBy(value => value).OrderBy(group => group.Count());
            if (valuesOrderedByCount.First().Count() == valuesOrderedByCount.Last().Count())
                return 0;

            var groupedValues = valuesOrderedByCount.Select(group => group.Key);
            return groupedValues.First();
        }
    }
}
