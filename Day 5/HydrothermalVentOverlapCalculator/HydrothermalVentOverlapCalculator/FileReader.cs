namespace HydrothermalVentOverlapCalculator
{
    public static class FileReader
    {
        public static List<HydrothermalVentLine> RetrieveReadings(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var hydrothermalVentLines = new List<HydrothermalVentLine>();
            foreach (var line in lines)
            {
                var coordinateGroups = line.Split(" -> ");
                for (int i = 0; i < coordinateGroups.Length; i += 2)
                {
                    var startingCoordinateGroup = coordinateGroups[i].Split(',');
                    var endingCoordinateGroup = coordinateGroups[i + 1].Split(',');

                    var startingCoordinate = new Coordinate(int.Parse(startingCoordinateGroup.First()), int.Parse(startingCoordinateGroup.Last()));
                    var endingCoordinate = new Coordinate(int.Parse(endingCoordinateGroup.First()), int.Parse(endingCoordinateGroup.Last()));

                    hydrothermalVentLines.Add(new HydrothermalVentLine(startingCoordinate, endingCoordinate));
                }
            }

            return hydrothermalVentLines;
        }
    }
}
