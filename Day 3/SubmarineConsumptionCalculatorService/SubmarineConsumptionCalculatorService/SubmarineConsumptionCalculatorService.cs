using SubmarineConsumptionCalculatorService;

var rows = FileReader.ReadFile("input.txt");
var values = BitPositionValueParser.GetColumnValues(rows);
var powerConsumption = PowerConsumptionCalculator.CalculatePowerConsumption(values);
var lifeSupportRating = LifeSupportRatingCalculator.CalculateLifeSupportRating(values, rows);

Console.WriteLine($"Power consumption: {powerConsumption}");
Console.WriteLine($"Life support rating: {lifeSupportRating}");
