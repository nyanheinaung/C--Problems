using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] hw = line.Split(' ');
        int h = Int32.Parse(hw[0]);
        int w = Int32.Parse(hw[1]);
        
        char[,] grid = new char[h,w];
        
        for(int i = 0; i < h; i++)
        {
            string temp = Console.ReadLine();
            for(int j = 0; j < w; j++)
            {
                grid[i,j] = temp[j];
            }
        }
        
        int[,] explosions = new int[h,w];        
        int maxExplosions = 0;
        
        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                if(grid[i,j] == '#')
                {
                  for(int k = 0; k < w; k++)
                  {
                      explosions[i,k] = 1;
                  }
                  
                  for(int l = 0; l < h; l++)
                  {
                      explosions[l,j] = 1;
                  }
                }
            }
        }
        
        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                maxExplosions += explosions[i,j];
            }
        }

        Console.WriteLine(maxExplosions);
    }
}