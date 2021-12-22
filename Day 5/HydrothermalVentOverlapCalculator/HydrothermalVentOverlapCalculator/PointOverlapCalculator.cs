namespace HydrothermalVentOverlapCalculator
{
    public static class PointOverlapCalculator
    {
        public static int CalculateOverlappingPoints(List<HydrothermalVentLine> readings)
        {
            var linePoints = readings.SelectMany(reading => reading.GetPoints()).ToList();
            return linePoints.GroupBy(point => point).Where(group => group.Count() > 1).Count();
        }
    }
}
