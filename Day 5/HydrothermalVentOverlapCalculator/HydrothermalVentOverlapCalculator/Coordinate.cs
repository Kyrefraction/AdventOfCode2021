namespace HydrothermalVentOverlapCalculator
{
    //Using a record here instead of a class to group by structural equality and not referential equality
    public record Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
