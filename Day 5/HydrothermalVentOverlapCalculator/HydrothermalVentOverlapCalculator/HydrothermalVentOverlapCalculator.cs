using HydrothermalVentOverlapCalculator;

var readings = FileReader.RetrieveReadings("input.txt");
var overlappingPoints = PointOverlapCalculator.CalculateOverlappingPoints(readings);

Console.WriteLine($"There are {overlappingPoints} points that overlap");