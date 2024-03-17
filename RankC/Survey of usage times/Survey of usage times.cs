using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int totalGift = Int32.Parse(line);
        string[] id_string = Console.ReadLine().Split(' ');

        int[] id_int = new int[id_string.Length];

        for (int i = 0; i < id_string.Length; i++)
        {
            id_int[i] = Int32.Parse(id_string[i]);
        }

        Array.Sort(id_int);

        int index = 0;
        int[] uniqueID = new int[id_int.Length];



        for (int i = 0; i < id_int.Length - 1; i++)
        {
            uniqueID[index]++;

            if (id_int[i] != id_int[i + 1])
            {
                index++;
            }
        }

        uniqueID[index]++;

        int largestNumber = uniqueID.Max();

        string result = "";

        bool firstOccurance = false;

        for (int i = 0; i < uniqueID.Length; i++)
        {
            if (uniqueID[i] == largestNumber && firstOccurance)
            {
                result = result + " " + (i + 1);
            }
            else if (uniqueID[i] == largestNumber && !firstOccurance)
            {
                result = result + (i + 1);
                firstOccurance = !firstOccurance;
            }

        }

        Console.WriteLine(result);
    }
}