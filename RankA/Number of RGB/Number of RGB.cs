using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] hw = line.Split(' ');
        int h = Convert.ToInt32(hw[0]);
        int w = Convert.ToInt32(hw[1]);
        
        char[,] grid = new char[h,w];
        
        for(int i = 0; i < h; i++)
        {
            string temp = Console.ReadLine();
            for(int j = 0; j < w; j++)
            {
                grid[i,j] = temp[j];
            }
        }
        
        int red = 0;
        int green = 0;
        int blue = 0;
        
        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                char color = grid[i,j];
                if(color == 'R')
                {
                    red++;
                }
                else if(color == 'G')
                {
                    green++;
                }
                else if(color == 'B')
                {
                    blue++;
                }
                
                grid = findAdjacent(grid, i, j, color, h, w);
            }
        }

        Console.WriteLine(red + " " + green + " " + blue);
    }
    
    static char[,] findAdjacent(char[,] grid, int i, int j, char color, int h, int w)
    {
        if(grid[i,j] == 'D' || grid[i,j] != color)
        {
            return grid;
        }
        
        grid[i,j] = 'D';
        
        int[,] directions = {{1,0},{0,1},{-1,0},{0,-1}};
        
        for(int k = 0; k < 4; k++)
        {
            int newI = i + directions[k,0];
            int newJ = j + directions[k,1];
            
            if(newI >= 0 && newJ >= 0 && newI < h && newJ < w)
            {
                findAdjacent(grid, newI, newJ, color, h, w);           
            }
        }
        
        return grid;
    }
}