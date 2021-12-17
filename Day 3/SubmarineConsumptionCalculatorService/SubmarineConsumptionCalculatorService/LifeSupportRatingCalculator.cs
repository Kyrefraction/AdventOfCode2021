namespace SubmarineConsumptionCalculatorService
{
    public static class LifeSupportRatingCalculator
    {
        public static int CalculateLifeSupportRating(Dictionary<int, List<string>> values, List<string> rows)
        {
            var oxygenGeneratorRatingBinary = DiagnosticNumberCalculator.GetOxygenGeneratorRating(values, rows);
            var carbonDioxideScrubberRatingBinary = DiagnosticNumberCalculator.GetCarbonDioxideScrubberRating(values, rows);

            var oxygenGeneratorRatingDenary = Convert.ToInt32(oxygenGeneratorRatingBinary, 2);
            var carbonDioxideGeneratorRatingDenary = Convert.ToInt32(carbonDioxideScrubberRatingBinary, 2); 

            return oxygenGeneratorRatingDenary * carbonDioxideGeneratorRatingDenary;
        }
    }
}
