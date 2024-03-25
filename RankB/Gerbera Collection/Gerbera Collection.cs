using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int variety = Int32.Parse(line);
        int total = variety * 2;
        
        int[] gerberas = new int[total];
        
        for(int i = 0; i < total; i++)
        {
            gerberas[i] = Int32.Parse(Console.ReadLine());
        }
        
        int swapCount = 0;
        
        for(int i = 0; i < variety; i++)
         {
             int index = Array.IndexOf(gerberas,i+1);
             
             while(gerberas[i] != gerberas[index])
             {
                 int temp = gerberas[index  - 1];
                 gerberas[index - 1] = gerberas[index];
                 gerberas[index] = temp;
                 index--;
                 
                 swapCount++;
             }
         }

        int[] secondPart = new int[variety];
        
        for(int i = 0; i < variety; i++)
        {
            secondPart[i] = gerberas[i + variety];
        }
        
        for(int i = 0; i < variety; i++)
         {
             int index = Array.IndexOf(secondPart,i+1);
             
             while(secondPart[i] != secondPart[index])
             {
                 int temp = secondPart[index  - 1];
                 secondPart[index - 1] = secondPart[index];
                 secondPart[index] = temp;
                 index--;
                 
                 swapCount++;
             }
         }
        
        
        
        Console.WriteLine(swapCount);
    }
}