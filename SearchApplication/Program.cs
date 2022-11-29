using SearchApplication;

namespace SearchApplication
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            Grid grid = new Grid
            {   
                Obstacles = new List<int> { }
            };

            CreateGrid displayGrid = new CreateGrid();

            Console.Write("Input start node: ");
            int startNode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input goal node: ");
            int goalNode = Convert.ToInt32(Console.ReadLine());

            displayGrid.DrawGrid(0, 0, new int[0].ToList(), grid);

            Console.WriteLine("Input position of obstacles(10): ");
            
            for (int i = 0; i < 10; i++)
            {
                int obstacle = Convert.ToInt32(Console.ReadLine());
                grid.Obstacles.Add(obstacle);
            }
            

            BFSAlgorithm search = new BFSAlgorithm(grid, goalNode);
            

            var path = search.GetPath(startNode);
            displayGrid.DrawGrid(startNode, goalNode, path.ToList(), grid);
        }

    }
}