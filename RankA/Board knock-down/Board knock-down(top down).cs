using System;
class Program
{
    static int maxScore = 0;

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

        for (int col = 0; col < w; col++)
        {
            int currentScore = board[0, col];
            FindCurrentScore(board, currentScore, col, 1, h, w);
        }

        Console.WriteLine(maxScore);
    }

    static int FindCurrentScore(int[,] board, int currentScore, int col, int row, int h, int w)
    {
        int score = currentScore;

        if (row == h)
        {
            maxScore = (currentScore > maxScore) ? currentScore : maxScore;

            return currentScore;
        }

        for (int i = col - 1; i <= col + 1; i++)
        {
            if (i >= 0 && i < w)
            {
                int point = board[row, i];

                score += point;

                //Console.WriteLine(row + "    " + i );

                score = FindCurrentScore(board, score, i, row + 1, h, w);

                // Console.WriteLine(score+ "    " + point + "    " + row + "    " + i );

                score -= point;
            }

        }

        return currentScore;
    }
}