using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();

        string wageAndMinute = (string)line;
        string sWage = "";
        string sMinute = "";
        bool spaceFound = false;

        for (int i = 0; i < wageAndMinute.Length; i++)
        {
            if (wageAndMinute[i] == ' ')
            {
                spaceFound = !spaceFound;
            }
            else if (!spaceFound)
            {
                sWage = sWage + wageAndMinute[i];
            }
            else
            {
                sMinute = sMinute + wageAndMinute[i];
            }

        }

        int wage = Int32.Parse(sWage);
        int minute = Int32.Parse(sMinute);

        int salary = wage * minute / 60;

        Console.WriteLine(salary);
    }
}