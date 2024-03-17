using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] given = line.Split(' ');
        int outputLength = 0;
        int firstNumberLength = given[0].Length;
        int SecondNumberLength = given[1].Length;
        int firstNumber = Int32.Parse(given[0]);
        int secondNumber = Int32.Parse(given[1]);


        if (firstNumberLength >= SecondNumberLength)
        {
            outputLength = firstNumberLength;
        }
        else
        {
            outputLength = SecondNumberLength;
        }

        int[] output = new int[outputLength];
        //int digitDifference = firstNumberLength - SecondNumberLength;

        for (int i = 0; i < outputLength; i++)
        {

            int firstDigit = firstNumber % 10;
            firstNumber -= firstDigit;
            firstNumber /= 10;

            int secondDigit = secondNumber % 10;
            secondNumber -= secondDigit;
            secondNumber /= 10;

            int addition = firstDigit + secondDigit;
            int carryoverCancel = addition % 10;

            output[i] = carryoverCancel;
        }

        string outputString = "";

        for (int i = 0; i < outputLength; i++)
        {
            outputString += output[outputLength - i - 1];
        }

        Console.WriteLine(outputString);
    }
}