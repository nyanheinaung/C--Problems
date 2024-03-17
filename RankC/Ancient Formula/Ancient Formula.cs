using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string formula = (string)line;

        int total = 0;

        for (int i = 0; i < formula.Length; i++)
        {
            if (formula[i] == '/')
            {
                total++;
            }

            if (formula[i] == '<')
            {
                total += 10;
            }

        }



        Console.WriteLine(total);
    }
}