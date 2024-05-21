using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] volcanoAndRadius = line.Split(' ');
        int volcanoesCount = Int32.Parse(volcanoAndRadius[0]);
        int radius = Int32.Parse(volcanoAndRadius[1]);
        int[,] coordinates = new int[volcanoesCount,2];
        
        for(int i = 0; i < volcanoesCount; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            coordinates[i,0] = Int32.Parse(temp[0]);
            coordinates[i,1] = Int32.Parse(temp[1]);
        }
        
        int x = 0;
        int y = 0;

        for(int i = 0; i < volcanoesCount; i++)
        {
            x = coordinates[i,0] > x ? coordinates[i,0] : x;
            y = coordinates[i,1] > y ? coordinates[i,1] : y;
        }  
        
        int largestX = x + 1;
        int largestY = y + 1;
        
        int[,] grid = new int[largestX,largestY];
        
        for(int i = 0; i < volcanoesCount; i++)
        {
            grid[coordinates[i,0],coordinates[i,1]] = 1;
        }      
        
        int numberOfIslands = 0;

        for(int i = 0; i < largestX; i++)
        {
            for(int j = 0; j < largestY; j++)
            {
                if(grid[i,j]==1)
                {
                    grid[i,j] = 0;
                    numberOfIslands++;
                    grid = FindAdjacentIsland(i,j,radius,grid,largestX,largestY);
                }
            }
            
        }

        Console.WriteLine(numberOfIslands);
    }
    
    static int[,] FindAdjacentIsland(int i, int j, int radius, int[,] grid, int largestX, int largestY)
    {
        int[,] newGrid = new int[largestX,largestY];
        newGrid = grid;
        for(int k = (i - radius * 2); k <= (i + radius * 2); k++)
        {
            for(int l = (j - radius * 2); l <= (j + radius * 2); l++)
            {
                int kBound = Clamp(k,0,largestX-1);
                int lBound = Clamp(l,0,largestY-1);
                
                double distance = Math.Sqrt((k-i)*(k-i) + (l-j)*(l-j));

                if(distance <= (radius * 2) && grid[kBound,lBound] == 1)
                {
                    newGrid[kBound,lBound] = 0;
                    newGrid = FindAdjacentIsland(kBound,lBound,radius,newGrid, largestX,largestY);
                }
            }
        }
        
        return newGrid;
        
    }

    static int Clamp(int value, int min, int max)
    {
        return Math.Max(min, Math.Min(max, value));
    }
}