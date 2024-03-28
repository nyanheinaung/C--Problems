using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] bookDays = line.Split(' ');
        int bookCount = Convert.ToInt32(bookDays[0]);
        int vacationDays = Convert.ToInt32(bookDays[1]);
        
        int[] pages = new int[bookCount];
        int[] days = new int[bookCount];
        
        for(int i = 0; i < bookCount; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            pages[i] = Convert.ToInt32(temp[0]);
            days[i] = Convert.ToInt32(temp[1]);
        }
        
        int maxPages = KnapSack(vacationDays, days, pages, bookCount);
        
        Console.WriteLine(maxPages);
    }
    
    static int KnapSack(int vacationDays, int[] days, int[] pages, int bookCount)
    {
        int[,] K = new int[bookCount+1, vacationDays+1];
        
        for(int i = 0; i <= bookCount; i++)
        {
            for(int j = 0; j <= vacationDays; j++)
            {
                if(i == 0 || j == 0)
                {
                    K[i,j] = 0;
                }
                else if(days[i-1] <= j)
                {
                    K[i,j] = Math.Max(pages[i-1] + K[i-1,j-days[i-1]],K[i-1,j]);
                }
                else
                {
                    K[i,j] = K[i-1,j];
                }
            }
        }
        
        
        
        return K[bookCount, vacationDays];
    }
}