using SubmarinePositionCalculator;

var rows = FileReader.ReadFile("input.txt");
var commands = CommandParser.Parse(rows);

var displacementArea = PositionCalculator.CalculateDisplacementArea(commands);
var aimedDisplacementArea = PositionCalculator.CalculateAimedDisplacementArea(commands);

Console.WriteLine($"Simple displacement area: {displacementArea}");
Console.WriteLine($"Aimed displacement area: {aimedDisplacementArea}");
