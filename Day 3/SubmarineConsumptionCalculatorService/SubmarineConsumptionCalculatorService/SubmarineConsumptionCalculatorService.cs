using SubmarineConsumptionCalculatorService;

namespace SubmarineCinsumptionCalculatorService
{
    public class SubmarineConsumptionCalculatorService
    {
        public static void Main(string[] args)
        {
            var rows = FileReader.ReadFile("input.txt");
            var values = BitPositionValueParser.GetColumnValues(rows);
            var powerConsumption = PowerConsumptionCalculator.CalculatePowerConsumption(values);

            Console.WriteLine(powerConsumption);
        }
    }
}