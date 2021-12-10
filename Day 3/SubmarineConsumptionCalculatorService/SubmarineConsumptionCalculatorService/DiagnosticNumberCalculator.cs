namespace SubmarineConsumptionCalculatorService
{
    public static class DiagnosticNumberCalculator
    {
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
            return values.GroupBy(value => value).OrderByDescending(group => group.Count()).Select(group => group.Key).First();
        }

        private static string GetLeastCommonValue(List<string> values)
        {
            var integerList = values.Select(int.Parse).ToList();
            return $"{GetLeastCommonValue(integerList)}";
        }

        private static int GetLeastCommonValue(List<int> values)
        {
            return values.GroupBy(value => value).OrderBy(group => group.Count()).Select(group => group.Key).First();
        }
    }
}
