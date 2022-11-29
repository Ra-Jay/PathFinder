
namespace SearchApplication
{
    public class CreateGrid
    {
        /// <summary>
        /// Draws the grid
        /// </summary>
        /// <param name="start">starting node</param>
        /// <param name="goal">goal node</param>
        /// <param name="path">list of nodes that representst the shortest path from the start to the goal</param>
        /// <param name="grid">contains the obstacles in the grid</param>
        public void DrawGrid(int start, int goal, List<int> path, Grid grid)
        {
            int currNode;
            int prevNode;

            Console.Write("\nPath: ");
            foreach(var item in path)
            {
                if(item == start - 1 || item == start + 1 || item == start - 10 || item == start - 10)
                    Console.Write(item);
                else
                    Console.Write(item + " → ");
            }
            Console.WriteLine("\n");
            for (var index = 1; index <= 100; index++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if(index == start)                          //Start
                    Console.Write("S ");
                else if (path.Contains(index))              //Path
                {
                    int temp = path.IndexOf(index);
                    currNode = path.ElementAt(temp);
                    int tempNode = 0;
                    if(temp < path.Count-1)
                        tempNode = path.ElementAt(temp + 1);
                    if (temp != 0)
                        prevNode = path.ElementAt(temp - 1);
                    else
                        prevNode = index;

                    if (index == goal)
                        Console.Write("G ");
                    else if (currNode - prevNode == -10) //Path is going down
                        Console.Write("↓ ");
                    else if (currNode - prevNode == 10)//Path is going up
                        Console.Write("↑ ");
                    else if (currNode - prevNode == -1)  //Path is going right
                        Console.Write("→ ");
                    else if (currNode - prevNode == 1) //Path is going left
                        Console.Write("- ");
                    else
                        Console.Write(" " + "\t");
                    
                }
                else if (grid.Obstacles.Contains(index))    //Obstacles
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("■ ");
                }
                else if (start == 0 && goal == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{index}\t");
                }
                else                                        //Available nodes
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("O ");
                }


                if (index % 10 == 0)
                    Console.WriteLine("\t");
            }
            Console.WriteLine("");
        }
    }

}
