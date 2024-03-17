using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string code = (string)line;
        string decode = "";

        for (int i = 0; i < code.Length; i = i + 2)
        {
            decode = decode + code[i];
        }

        Console.WriteLine(decode);
    }
}