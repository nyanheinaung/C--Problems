using System.Collections.Generic;
using System;

public class Hello{
    public static void Main(){
        
        string[] NKM = Console.ReadLine().Split(' ');
        int N = Convert.ToInt32(NKM[0]); // participants count
        int K = Convert.ToInt32(NKM[1]); // word count
        int M = Convert.ToInt32(NKM[2]); // comment count
        
        // Create participants group
        List<int> participants = new List<int>();
        
        for(int i = 0; i < N; i++)
        {
            participants.Add(i);
        }
        
        // Create Legal words group
        List<string> words = new List<string>();
        
        for(int i = 0; i < K; i++)
        {
            words.Add(Console.ReadLine());
        }
        
        string currentComment = "";
        string previousComment = "";
        bool valid = true;
        int turnIndex = 0;
        int remainingPlayers = N;
        
        for(int i = 0; i < M; i++)
        {
            currentComment = Console.ReadLine();
            
            valid = CheckComment(currentComment, previousComment, words);
            
            if(valid)
            {
                previousComment = currentComment;
                turnIndex++;
            }
            else
            {
                previousComment = "";
                remainingPlayers--;
                
                participants.RemoveAt(turnIndex);
                
            }
            
            turnIndex = (turnIndex >= remainingPlayers) ? 0 : turnIndex;
            
        }
        
        Console.WriteLine(remainingPlayers);
                    
        foreach(int participant in participants)
        {
            Console.WriteLine(participant + 1);
        }
        
    }
    
    static bool CheckComment(string currentComment, string previousComment, List<string> words)
    {
        bool wordChain = false;
        bool stillInWords = false;
        bool notEndWithZ = false;
        
        if(previousComment == "")
        {
            wordChain = true;
        }
        else if(previousComment[previousComment.Length - 1] == currentComment[0])
        {
            wordChain = true;
        }            
        
        
        foreach(string word in words)
        {
            if(currentComment == word)
            {
                stillInWords = true;
                break;
            }
        }            
        
        if(stillInWords)
        {
            words.Remove(currentComment);
        }
        
        if(currentComment[currentComment.Length - 1] != 'z')
        {
            notEndWithZ = true;
        }

        return (wordChain && stillInWords && notEndWithZ);
    }
    
}