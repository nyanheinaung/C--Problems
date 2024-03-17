using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int powerTypes = Int32.Parse(line);

        int[] inventory = new int[powerTypes];

        for (int i = 0; i < powerTypes; i++)
        {
            inventory[i] = Int32.Parse(Console.ReadLine());
        }

        int customerCount = Int32.Parse(Console.ReadLine());
        int[,] powerRequirement = new int[customerCount, 2];

        int customerServed = 0;

        for (int i = 0; i < customerCount; i++)
        {
            string[] powerLR = Console.ReadLine().Split(' ');
            int l = Int32.Parse(powerLR[0]) - 1;
            int r = Int32.Parse(powerLR[0]) - 1;

            if (l == r)
            {
                if (inventory[l] > 1)
                {

                    inventory[l]--;
                    inventory[r]--;

                    customerServed++;
                }

            }
            else
            {

                if (inventory[l] > 0 && inventory[r] > 0)
                {

                    inventory[l]--;
                    inventory[r]--;

                    customerServed++;
                }

            }
        }

        Console.WriteLine(customerServed);
    }
}