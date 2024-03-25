using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int mapSize = Int32.Parse(line);
        
        int[,] map = new int[mapSize, mapSize];
        
        for(int i = 0; i < mapSize; i++)
        {
            string[] mapRow = Console.ReadLine().Split(' ');
            
            for(int j = 0; j < mapSize; j++)
            {
                map[i,j] = Int32.Parse(mapRow[j]);
            }
        }
        
        int enlargedMapSize = mapSize + 2;
        int[,] enlargedMap = new int[enlargedMapSize, enlargedMapSize];
        
        for(int i = 1; i < enlargedMapSize - 1; i++)
        {
            for(int j = 1; j < enlargedMapSize - 1; j++)
            {
                enlargedMap[i,j] = map[i-1,j-1];
            }
        }      
        
        List<int> peaks = new List<int>();
        
        for(int i = 1; i < enlargedMapSize - 1; i++)
        {
            for(int j = 1; j < enlargedMapSize - 1; j++)
            {
                int current = enlargedMap[i,j];
                int north = enlargedMap[i,j+1];
                int east = enlargedMap[i+1,j];
                int south = enlargedMap[i,j-1];
                int west = enlargedMap[i-1,j];
                
                if(current > north && current > east && current > south && current > west)
                {
                    peaks.Add(enlargedMap[i,j]);
                }
            }
        }
        
        var sortedPeaks = peaks.OrderByDescending(x => x).ToList();
        
        foreach(int peak in sortedPeaks)
        {
            Console.WriteLine(peak);
        }

    }
}