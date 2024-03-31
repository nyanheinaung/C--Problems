using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int gridSize = Int32.Parse(line);
        int[,] grid = new int[gridSize,gridSize];
        
        for(int i = 0; i < gridSize; i++)
        {
            string temp = Console.ReadLine();
            for(int j = 0; j < gridSize; j++)
            {
                grid[i,j] = (int)Char.GetNumericValue(temp[j]);

            }
        }
        
        int longestSwipe = 1;
        
        for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                int newSwipe = findLongestSwipe(grid, i, j, gridSize);
                longestSwipe = newSwipe > longestSwipe ?  newSwipe : longestSwipe;
            }
        }
        
        longestSwipe = longestSwipe == 1 ? 0 : longestSwipe;
        
        Console.WriteLine(longestSwipe);
    }
    
    static int findLongestSwipe(int[,] grid, int row, int column, int gridSize)
    {
        int[,] directions = {{1,0},{1,1},{0,1},{-1,1},{-1,0},{-1,-1},{0,-1},{1,-1}};
        
        int longestSwipe = 1;
        int currentSwipe = 1;
        
        for(int i = 0; i < 8; i++)
        {
            bool ascending = true;
            bool firstTime =true;
            int dx = directions[i,0];
            int dy = directions[i,1];
            int currentRow = row;
            int currentColumn = column;
            int nextRow = currentRow + dx;
            int nextColumn = currentColumn +dy;
            
            while(nextRow >= 0 && nextRow < gridSize && nextColumn >= 0 && nextColumn < gridSize)
            {
                if(firstTime)
                {
                    if(grid[nextRow,nextColumn] == (grid[currentRow,currentColumn] + 1))
                    {
                        ascending = true;
                        currentSwipe++;
                    }
                    else if(grid[nextRow,nextColumn] == (grid[currentRow,currentColumn] - 1))
                    {
                        ascending = false;
                        currentSwipe++;
                    }
                    else
                    {
                        break;
                    }
                }

                if(!firstTime)
                {
                    if((grid[nextRow,nextColumn] == (grid[currentRow,currentColumn] + 1)) && ascending)
                    {
                        currentSwipe++;
                    }
                    else if((grid[nextRow,nextColumn] == (grid[currentRow,currentColumn] - 1)) && !ascending)
                    {
                        currentSwipe++;
                    }
                    else
                    {
                        break;
                    }
                }
                
                firstTime = false;
                
                currentRow = nextRow;
                currentColumn = nextColumn;
                nextRow += dx;
                nextColumn += dy;
            }

            longestSwipe = currentSwipe > longestSwipe ?  currentSwipe : longestSwipe;
            currentSwipe = 1;
        }

        return longestSwipe;
    }

}