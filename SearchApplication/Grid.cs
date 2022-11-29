
namespace SearchApplication
{
    public class Grid
    {
        public int width = 10;
        public int height = 10;
        public int NodeCount 
        { 
            get => width * height; 
        }
        public List<int> Obstacles { get; set; } = new List<int>();

        /// <summary>
        /// Checks the neighboring nodes of the input node
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>list of available nodes</returns>
        public IEnumerable<int> GetNeighboringNodes(int node)
        {
            int y = (int)(Math.Ceiling(node / (decimal)width));
            int x = node - ((y - 1) * width);

            //Checks the neighboring nodes in this order: Top, Bottom, Left, Right
            var neighboringNodes = new int?[] {
                GetTopNode(x, y),
                GetBottomNode(x, y),
                GetLeftNode(x, y),
                GetRightNode(x, y)
            };

            return neighboringNodes
                    .Where(n => n.HasValue && !Obstacles.Contains(n.Value))
                    .Select(n => n.Value);
        }

        private int? GetTopNode(int x, int y)
        {
            if(y > 1)
                return (y - 2) * width + x;
            return null;
        }

        private int? GetBottomNode(int x, int y)
        {
            if (y < height)
                return  y * width + x;
            return null;
        }

        private int? GetLeftNode(int x, int y)
        {
            if (x > 1)
                return (y - 1) * width + (x - 1);
            return null;
        }

        private int? GetRightNode(int x, int y)
        {
            if (x < width)
                return (y - 1) * width + (x + 1);
            return null;
        }
    }
}
