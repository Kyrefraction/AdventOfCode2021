using SubmarineConsumptionCalculatorService;

var rows = FileReader.ReadFile("input.txt");
var values = BitPositionValueParser.GetColumnValues(rows);
var powerConsumption = PowerConsumptionCalculator.CalculatePowerConsumption(values);

Console.WriteLine(powerConsumption);
