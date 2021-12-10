namespace SubmarineConsumptionCalculatorService
{
    public static class PowerConsumptionCalculator
    {
        public static int CalculatePowerConsumption(Dictionary<int, List<string>> values)
        {
            var gammaBinaryNumber = DiagnosticNumberCalculator.GetGammaDiagnosticValue(values);
            var epsilonBinaryNumber = DiagnosticNumberCalculator.GetEplisonDiagnosticValue(values);

            var gammaDenaryNumber = Convert.ToInt32(gammaBinaryNumber, 2);
            var epsilonDenaryNumber = Convert.ToInt32(epsilonBinaryNumber, 2);

            return gammaDenaryNumber * epsilonDenaryNumber;
        }
    }
}
