using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] hw = line.Split(' ');
        int h = Convert.ToInt32(hw[0]);
        int w = Convert.ToInt32(hw[1]);

        int[,] board = new int[h, w];

        for (int i = 0; i < h; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            for (int j = 0; j < w; j++)
            {
                board[i, j] = Convert.ToInt32(temp[j]);
            }
        }

        int[,] scoreBoard = new int[h, w];

        for (int i = 0; i < w; i++)
        {
            scoreBoard[h - 1, i] = board[h - 1, i];
        }

        for (int j = h - 2; j >= 0; j--)
        {
            for (int i = 0; i < w; i++)
            {
                int left = 0;
                int middle = scoreBoard[j + 1, i];
                int right = 0;

                if (i - 1 >= 0)
                {
                    left = scoreBoard[j + 1, i - 1];
                }

                if (i + 1 < w)
                {
                    right = scoreBoard[j + 1, i + 1];
                }

                int max = Math.Max(left, Math.Max(middle, right));

                scoreBoard[j, i] = board[j, i] + max;
            }
        }

        int maxNumber = 0;

        for (int i = 0; i < w; i++)
        {
            maxNumber = scoreBoard[0, i] > maxNumber ? scoreBoard[0, i] : maxNumber;
        }

        Console.WriteLine(maxNumber);
    }