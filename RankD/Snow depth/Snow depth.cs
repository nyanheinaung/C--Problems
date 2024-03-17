using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();

        string given = (string)line;
        bool spaceFound = false;
        string firstDayString = "";
        string secondDayString = "";
        for (int i = 0; i < given.Length; i++)
        {
            if (given[i] == ' ')
            {
                spaceFound = !spaceFound;
            }
            else if (spaceFound)
            {
                firstDayString = firstDayString + given[i];
            }
            else
            {
                secondDayString = secondDayString + given[i];
            }
        }

        int firstDayDepth = Int32.Parse(firstDayString);
        int secondDayDepth = Int32.Parse(secondDayString);

        int totalDepth = firstDayDepth + secondDayDepth;

        Console.WriteLine(totalDepth);
    }
}