using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int count = Convert.ToInt32(line);
        int totalCount = count * 2;

        int[] cards = new int[totalCount];
        int[,] helper = new int[totalCount, 2];

        for (int i = 0; i < totalCount; i++)
        {
            cards[i] = Convert.ToInt32(Console.ReadLine());
            helper[i, 0] = cards[i];
        }

        int complexity = 0;

        for (int i = 0; i < totalCount; i++)
        {
            int searchNum = cards[i];
            int index = Array.IndexOf(cards, searchNum);
            if (helper[index, 1] == 0)
            {
                helper[index, 1] = 1;
            }
            else
            {
                complexity += i - index - 1;
            }
        }

        Console.WriteLine(complexity);
    }
}