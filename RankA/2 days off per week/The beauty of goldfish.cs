using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int numberOfDays = Convert.ToInt32(line);
        int[] days = new int[numberOfDays];
        string[] tempDays = Console.ReadLine().Split(' ');
        
        for(int i = 0; i < numberOfDays; i++)
        {
            days[i] = Convert.ToInt32(tempDays[i]);
            
        }
        
        int maxNumberOfDays = 0;
        int validDays = 0;
        bool valid = true;
        
        for(int i = 0; i < numberOfDays - 6; i++)
        {
            int firstDay = days[i];
            int secondDay = days[i+1];
            int thirdDay = days[i+2];            
            int fourthDay = days[i+3];            
            int fifthDay = days[i+4];            
            int sixthDay = days[i+5];            
            int seventhDay = days[i+6]; 
            
            int consecutiveWorkingDays = firstDay + secondDay + thirdDay + fourthDay + fifthDay + sixthDay + seventhDay;

            if(consecutiveWorkingDays <= 5 && valid)
            {
                validDays = 7;
                valid = false;
            }
            else if(consecutiveWorkingDays <= 5)
            {
                validDays++;
                maxNumberOfDays = validDays > maxNumberOfDays ? validDays : maxNumberOfDays;
            }
            else
            {
                validDays = 0;
                valid = true;
            }
        }
        
        Console.WriteLine(maxNumberOfDays);
    }
}