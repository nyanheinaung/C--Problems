using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

        var line = Console.ReadLine();
        string[] temp = line.Split(' ');
        int cardCount = temp.Length;
        List<int> cards = new List<int>();
        var dict = new Dictionary<int,int>();
        
        
        
        cards.Clear();
        
        for(int i = 0; i < cardCount; i++)
        {
            cards.Add(Int32.Parse(temp[i]));
        }
        
        List<int> sortedCards = cards.OrderByDescending(x => x).ToList();




        foreach(int value in sortedCards)
        {
            dict.TryGetValue(value, out int count);
            dict[value] = count + 1;
        }
        
        int serialFirst = Serial(sortedCards,true);

        
        cards.Clear();
        
        for(int i = 0; i < cardCount; i++)
        {
            cards.Add(Int32.Parse(temp[i]));
        }
        
        sortedCards = cards.OrderByDescending(x => x).ToList();
        
        
        
        
            
        int multipleFirst = Multiple(dict,sortedCards,true);

        int maxScore = Math.Max(serialFirst,multipleFirst);

        Console.WriteLine(maxScore);

    }
    
    static int Multiple(Dictionary<int,int> dict, List<int> cards, bool first) 
    {
        int score = 0;
        var newCards = new List<int>();
        newCards = cards;
        foreach(var pair in dict)
        {
            if(pair.Value >= 3)
            {
                for(int i = 0; i < 3; i++)
                {
                    newCards.Remove(pair.Key);                    
                }
                score+=2;
            }
        }

        if(first)
        {
            score+=Serial(newCards,false);
        }
        
        return score;
    }
    
    static int Serial(List<int> cards, bool first)
    {
        int score = 0;
        var newCards = new List<int>();
        newCards = cards;
        int listLength = newCards.Count;

        int countLoop = 0;
            
        while(countLoop < listLength)
        {
            int firstNumber = newCards[countLoop];
            int secondNumber = newCards[countLoop] - 1;
            int thirdNumber = newCards[countLoop] - 2;            
            
            bool second = newCards.Contains(secondNumber);
            bool third = newCards.Contains(thirdNumber);

            if(second && third)
            {
                newCards.Remove(firstNumber);
                newCards.Remove(secondNumber);
                newCards.Remove(thirdNumber);
                score+=1;

            }
            else
            {
                countLoop++;    
            }

            listLength = newCards.Count;
        }

        var newDict = new Dictionary<int,int>();
        foreach(int value in newCards)
        {
            newDict.TryGetValue(value, out int count);
            newDict[value] = count + 1;
        }
        
        if(first)
        {
            score+=Multiple(newDict,newCards,false);
        }

        return score;
    }
    
}