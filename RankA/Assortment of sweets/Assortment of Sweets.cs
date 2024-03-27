using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] typeAndAllowance = line.Split(' ');
        int types = Convert.ToInt32(typeAndAllowance[0]);
        int allowance = Convert.ToInt32(typeAndAllowance[1]);
        
        int[] sweets = new int[types];

        for(int i = 0; i < types; i++)
        {
            sweets[i] = Convert.ToInt32(Console.ReadLine());
        }
        
        int maxTypes = 0;
        int minChange = allowance;        
        
        int totalCombinations = 1 << types;
        
        for(int i = 1; i < totalCombinations; i++)
        {
            int tempType = 0;
            int maxCost = 0;
                
            for(int j = 0; j < types; j++)
            {
                if((i & (1 << j)) != 0)
                {
                    maxCost += sweets[j];
                    tempType++;
                }
            }
            
            if(maxCost <= allowance)
            {
                int currentChange = allowance - maxCost;
            
                maxTypes = tempType > maxTypes ? tempType : maxTypes;
                if(tempType >= maxTypes)
                {
                    maxTypes = tempType;
                    minChange = minChange > currentChange ? currentChange : minChange; 
                }
            }
            
        }
        
        
        Console.WriteLine(minChange);
    }
}