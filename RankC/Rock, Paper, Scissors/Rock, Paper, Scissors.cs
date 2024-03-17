using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();

        string numberOfMatchesString = (string)line;
        int numberOfMatches = Int32.Parse(numberOfMatchesString);

        string[] matches = new string[numberOfMatches];

        for (int i = 0; i < numberOfMatches; i++)
        {
            matches[i] = Console.ReadLine();
        }

        int wonMatches = 0;

        foreach (string match in matches)
        {
            char aliceChoice = match[0];
            char bobChoice = match[2];

            if (DecideWinner(aliceChoice, bobChoice) == 1)
            {
                wonMatches++;
            }
        }

        Console.WriteLine(wonMatches);
    }

    static int DecideWinner(char alice, char bob)
    {
        if (alice == 'G')
        {
            switch (bob)
            {
                case 'G': return 0;
                case 'C': return 1;
                case 'P': return -1;
            }
        }

        if (alice == 'C')
        {
            switch (bob)
            {
                case 'G': return -1;
                case 'C': return 0;
                case 'P': return 1;
            }
        }

        if (alice == 'P')
        {
            switch (bob)
            {
                case 'G': return 1;
                case 'C': return -1;
                case 'P': return 0;
            }
        }

        return 0;
    }
}