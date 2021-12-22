namespace HydrothermalVentOverlapCalculator
{
    public static class PointOverlapCalculator
    {
        public static int CalculateOverlappingPoints(List<HydrothermalVentLine> readings)
        {
            var linePoints = readings.SelectMany(reading => reading.GetPoints());
            return linePoints.GroupBy(point => point).Count(group => group.Count() > 1);
        }
    }
}
