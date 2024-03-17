using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int voteCount = Int32.Parse(line);
        int maxCandidateCount = 10;
        string[] candidateList = new string[maxCandidateCount];
        int candidateIndex = 0;

        string[,] candidateVoteSeperated = new string[voteCount, 2];

        for (int i = 0; i < voteCount; i++)
        {
            string[] candidateVote = Console.ReadLine().Split(' ');
            candidateVoteSeperated[i, 0] = candidateVote[0];
            candidateVoteSeperated[i, 1] = candidateVote[1];
        }

        int[,] voteAndShareCount = new int[maxCandidateCount, 2];
        int highestVotes = 0;
        int highestShare = 0;
        int candidateByFirstMethod = 0;
        int candidateBySecondMethod = 0;

        for (int i = 0; i < voteCount; i++)
        {
            for (int j = 0; j < maxCandidateCount; j++)
            {
                if (candidateList[j] == null)
                {
                    candidateList[j] = candidateVoteSeperated[i, 0];
                    voteAndShareCount[j, 0]++;
                    voteAndShareCount[j, 1] += Int32.Parse(candidateVoteSeperated[i, 1]);
                    if (highestVotes < voteAndShareCount[j, 0])
                    {
                        highestVotes = voteAndShareCount[j, 0];
                        candidateByFirstMethod = j;
                    }
                    if (highestShare < voteAndShareCount[j, 1])
                    {
                        highestShare = voteAndShareCount[j, 1];
                        candidateBySecondMethod = j;
                    }

                    break;
                }
                else if (candidateList[j] == candidateVoteSeperated[i, 0])
                {
                    voteAndShareCount[j, 0]++;
                    voteAndShareCount[j, 1] += Int32.Parse(candidateVoteSeperated[i, 1]);
                    if (highestVotes < voteAndShareCount[j, 0])
                    {
                        highestVotes = voteAndShareCount[j, 0];
                        candidateByFirstMethod = j;
                    }
                    if (highestShare < voteAndShareCount[j, 1])
                    {
                        highestShare = voteAndShareCount[j, 1];
                        candidateBySecondMethod = j;
                    }
                    break;
                }
            }
        }

        Console.WriteLine(candidateList[candidateByFirstMethod]);
        Console.WriteLine(candidateList[candidateBySecondMethod]);
    }

}