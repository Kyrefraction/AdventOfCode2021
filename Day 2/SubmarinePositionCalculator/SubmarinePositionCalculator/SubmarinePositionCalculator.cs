using SubmarinePositionCalculator;

var rows = FileReader.ReadFile("input.txt");
var commands = CommandParser.Parse(rows);
var displacementArea = PositionCalculator.CalculateDisplacementArea(commands);
Console.WriteLine(displacementArea);