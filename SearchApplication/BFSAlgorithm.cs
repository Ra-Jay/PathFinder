
namespace SearchApplication
{
    public  class BFSAlgorithm
    {
        private Grid _grid;
        private int _goal;
        public int[]? _edgesTo = new int[0];
        public int[]? _pathNodes = new int[0];

        public BFSAlgorithm(Grid grid, int goal)
        {
            _grid = grid;
            _goal = goal;
            ResetArray();
        }

        /// <summary>
        /// Sets the values of the whole array to -1
        /// </summary>
        private void ResetArray()
        {
            var arrLength = _grid.NodeCount + 1;
            _edgesTo = new int[arrLength];
            _pathNodes = new int[arrLength];

            for (int i = 0; i < arrLength; i++)
            {
                _pathNodes[i] = -1;
                _edgesTo[i] = -1;
            }
        }

        /// <summary>
        /// Looks for the shortest path
        /// </summary>
        /// <param name="start">start node</param>
        /// <returns>the path</returns>
        public int[] GetPath(int start)
        {
            var queue = new Queue<int>();
            var path = new int[0];

            if(start <=  0 || start > 100)
            {
                Console.WriteLine("\nInvalid start node!");
                return path;
            }

            queue.Enqueue(_goal);
            _pathNodes[_goal] = 0;
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var neighboringNode in _grid.GetNeighboringNodes(node))
                {
                    if (_pathNodes.Length >= (neighboringNode + 1) && _pathNodes[neighboringNode] == -1)
                    {
                        queue.Enqueue(neighboringNode);
                        _pathNodes[neighboringNode] = _pathNodes[node] + 1;
                        _edgesTo[neighboringNode] = node;
                    }
                }
            }

            var distance = _pathNodes[start];
            if (distance <= 0)
            {
                Console.WriteLine("\nNo available path");
                return path; 
            }

            if (_edgesTo[start] != 0)
            {
                path = new int[distance];
                while (start != _goal)
                {
                    start = _edgesTo[start];
                    path[--distance] = start;
                }
            }
            return path;
        }
    }
}
