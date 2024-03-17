using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string choice = (string)line;

        int nameCount = Int32.Parse(Console.ReadLine());

        string dishName = Console.ReadLine();
        string[] dishNameSeperated = dishName.Split(' ');

        string answer = "No";

        for (int i = 0; i < nameCount; i++)
        {
            if (dishNameSeperated[i] == choice)
            {
                answer = "Yes";
            }
        }

        Console.WriteLine(answer);
    }
}