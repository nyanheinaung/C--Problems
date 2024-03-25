using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] singerAndSongLength = line.Split(' ');
        int singerCount = Int32.Parse(singerAndSongLength[0]);
        int songLength = Int32.Parse(singerAndSongLength[1]);
        
        int[] correctPitch = new int[songLength];
        
        for(int i = 0; i < songLength; i++)
        {
            correctPitch[i] = Int32.Parse(Console.ReadLine());
            
        }
        
        int[,] actualPitch = new int[singerCount, songLength];
        
        for(int i = 0; i < singerCount; i++)
        {
            for(int j = 0; j < songLength; j++)
            {
                actualPitch[i,j] = Int32.Parse(Console.ReadLine());
            }
        }
        
        int[] points = new int[singerCount];
        
        for(int i = 0; i < singerCount; i++)
        {
            points[i] = 100;
        }

        for(int i = 0; i < singerCount; i++)
        {
            
            for(int j = 0; j < songLength; j++)
            {
                points[i]-=scoring(correctPitch[j],actualPitch[i,j]);
            }
            
            points[i] = Math.Max(points[i],0);
        }
        
        Console.WriteLine(points.Max());
    }
    
    static int scoring(int original, int actual)
    {
        if(Math.Abs(original-actual) <= 5)
        {
            return 0;
        }
        else if(Math.Abs(original-actual) <= 10)
        {
            return 1;
        }
        else if(Math.Abs(original-actual) <= 20)
        {
            return 2;
        }
        else if(Math.Abs(original-actual) <= 30)
        {
            return 3;
        }
        else
        {
            return 5;
        }

    }
    
    
}