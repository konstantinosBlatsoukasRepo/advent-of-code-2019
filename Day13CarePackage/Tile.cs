namespace Day13CarePackage
{
    public enum TileType
    {
        Empty, 
        Wall, 
        Block, 
        HorizontalPaddle,
        Ball        
    }

    public class Tile
    {
        public long DistanceFromLeft  { get; set; }

        public long DistanceFromTop { get; set; }

        public TileType TileType { get; set; }
    }
}
