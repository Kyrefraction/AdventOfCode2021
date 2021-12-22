namespace HydrothermalVentOverlapCalculator
{
    public class HydrothermalVentLine
    {
        public HydrothermalVentLine(Coordinate startingCoordinate, Coordinate endingCoordinate)
        {
            StartingCoordinate = startingCoordinate;
            EndingCoordinate = endingCoordinate;
        }

        private Coordinate StartingCoordinate { get; set; }
        private Coordinate EndingCoordinate { get; set; }

        public List<Coordinate> GetPoints()
        {
            var pointsCoordinates = new List<Coordinate>();

            if (IsVertical)
            {
                if (StartingCoordinate.Y > EndingCoordinate.Y)
                {
                    var temp = StartingCoordinate.Y;
                    StartingCoordinate.Y = EndingCoordinate.Y;
                    EndingCoordinate.Y = temp;
                }

                for (var y = StartingCoordinate.Y; y <= EndingCoordinate.Y; y++)
                {
                    pointsCoordinates.Add(new Coordinate(StartingCoordinate.X, y));
                }
            }

            if (IsHorizontal)
            {
                if (StartingCoordinate.X > EndingCoordinate.X)
                {
                    var temp = StartingCoordinate.X;
                    StartingCoordinate.X = EndingCoordinate.X;
                    EndingCoordinate.X = temp;
                }

                for (var x = StartingCoordinate.X; x <= EndingCoordinate.X; x++)
                {
                    pointsCoordinates.Add(new Coordinate(x, StartingCoordinate.Y));
                }
            }

            return pointsCoordinates;
        }

        private bool IsHorizontal => StartingCoordinate.Y == EndingCoordinate.Y;
        private bool IsVertical => StartingCoordinate.X == EndingCoordinate.X;
    }
}
