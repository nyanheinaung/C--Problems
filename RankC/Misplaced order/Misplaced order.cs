using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int orderCount = Int32.Parse(line);
        int[] requiredOrders = new int[orderCount];
        int[] arrivedOrders = new int[orderCount];

        for (int i = 0; i < orderCount; i++)
        {
            requiredOrders[i] = i + 1;
            arrivedOrders[i] = Int32.Parse(Console.ReadLine());
        }

        int missingOrders = 0;

        for (int i = 0; i < orderCount; i++)
        {
            bool correctOrder = false;

            for (int j = 0; j < orderCount; j++)
            {
                if (requiredOrders[i] == arrivedOrders[j])
                {
                    correctOrder = true;
                }
            }

            if (!correctOrder)
            {
                missingOrders++;
            }
        }

        Console.WriteLine(missingOrders);
    }
}