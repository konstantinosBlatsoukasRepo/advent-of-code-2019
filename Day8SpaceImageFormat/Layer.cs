namespace Day8SpaceImageFormat
{
    
    public class Layer
    {
        public int[,] pixels { get; set; }

        public Layer(int[,] pixelsIn)
        {
            pixels = pixelsIn;
        }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine();
        //    for (int currentRow = 0; currentRow < _height; currentRow++)
        //    {
        //        StringBuilder rowSb = new StringBuilder();
        //        for (int currentColumn = 0; currentColumn < _width; currentColumn++)
        //        {
        //            rowSb.AppendJoin(',', pixels[currentRow, currentColumn]);
        //        }
        //        sb.AppendLine(rowSb.ToString());
        //    }
        //    sb.AppendLine();

        //    return sb.ToString();
        //}

    }
}
