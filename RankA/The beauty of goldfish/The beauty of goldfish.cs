using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] Nx = line.Split(' ');
        int fishCount = Convert.ToInt32(Nx[0]);
        int durability = Convert.ToInt32(Nx[1]);

        int[,] fishes = new int[fishCount, 2];
        int[] helper = new int[fishCount];

        for (int i = 0; i < fishCount; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            fishes[i, 0] = Convert.ToInt32(temp[0]);
            fishes[i, 1] = Convert.ToInt32(temp[1]);
            helper[i] = i;
        }

        List<List<int>> combinations = CreateCombinations(helper);

        int maxBeauty = 0;

        foreach (List<int> combination in combinations)
        {
            int totalWeight = 0;
            int totalBeauty = 0;
            foreach (int i in combination)
            {
                if ((totalWeight + fishes[i, 0]) < durability)
                {
                    totalWeight += fishes[i, 0];
                    totalBeauty += fishes[i, 1];
                }
                else
                {
                    break;
                }
            }

            maxBeauty = totalBeauty > maxBeauty ? totalBeauty : maxBeauty;
        }

        Console.WriteLine(maxBeauty);
    }

    static List<List<int>> CreateCombinations(int[] helper)
    {
        List<List<int>> combinations = new List<List<int>>();

        for (int i = 1; i <= helper.Length; i++)
        {
            CombinationHelper(helper, new List<int>(), combinations, i, 0);
        }

        return combinations;
    }

    static void CombinationHelper(int[] helper, List<int> current, List<List<int>> combinations, int i, int start)
    {
        if (current.Count == i)
        {
            combinations.Add(new List<int>(current));
            return;
        }
        for (int j = start; j < helper.Length; j++)
        {
            current.Add(helper[j]);
            CombinationHelper(helper, current, combinations, i, j + 1);
            current.RemoveAt(current.Count - 1);
        }

    }
}