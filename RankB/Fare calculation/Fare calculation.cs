using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] lineAndStations = line.Split(' ');
        int lines = Int32.Parse(lineAndStations[0]);
        int stations = Int32.Parse(lineAndStations[1]);
        
        int[,] fareMap = new int[lines, stations];
        
        for(int i = 0; i < lines; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            
            for(int j = 0; j < stations; j++)
            {
                fareMap[i,j] = Int32.Parse(temp[j]);
            }
        }
        
        int numberOfStationsToPass = Int32.Parse(Console.ReadLine());
        
        int[,] travelRoute = new int[numberOfStationsToPass,2]; 
        
        for(int i = 0; i < numberOfStationsToPass; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            travelRoute[i,0] = Int32.Parse(temp[0]);
            travelRoute[i,1] = Int32.Parse(temp[1]);
        }
        
        int totalFare = 0;
        int currentLine = 0;
        int currentStation = 0;
       
        for(int i = 0; i < numberOfStationsToPass; i++)
        {
            currentLine = travelRoute[i,0] - 1;
            int destinationStation = travelRoute[i,1] - 1;
            totalFare += Math.Abs(fareMap[currentLine,currentStation] - fareMap[currentLine,destinationStation]);
            currentStation = destinationStation;
        }
        
        Console.WriteLine(totalFare);
    }
}