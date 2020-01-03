namespace Day10MonitoringStation
{
    public class CartesianCoordinate
    {
        public int X { get; }
        public int Y { get; }

        public Point Point { get; }
        public CartesianCoordinate(Point point, int columnReference, int rowReference)
        {
            var columnDiff = columnReference - point.Column;
            var rowDiff = rowReference - point.Row;

            Point = point;
            X = -columnDiff;
            Y = rowDiff;
        }
    }
}
