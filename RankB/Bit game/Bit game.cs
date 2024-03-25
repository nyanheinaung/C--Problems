using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        string[] playerNumAndDeck = line.Split(' ');
        
        int playerCount = Int32.Parse(playerNumAndDeck[0]);
        int deckCount = Int32.Parse(playerNumAndDeck[1]);
        
        int[,] playerHand = new int[playerCount, 3];
        
        for(int i = 0; i < playerCount; i++)
        {
            string[] tempHand = Console.ReadLine().Split(' ');
            for(int j = 0; j < 3; j++)
            {
                playerHand[i,j] = Int32.Parse(tempHand[j]);
            }
        }
        

        
        for(int i = 0; i < deckCount; i++)
        {
            string[] deck = Console.ReadLine().Split(' ');
            
            char shiftCode = deck[0][0];
            int[] tempDeck = new int[3];
            
            for(int j = 0; j < 3; j++)
            {
                tempDeck[j] = Int32.Parse(deck[j+1]);
            }
            
            for(int k = 0; k < playerCount; k++)
            {
                for(int l = 0; l < 3; l++)
                {
                    playerHand[k,l] = ShiftBit(playerHand[k,l], tempDeck[l],shiftCode);
                }
                 
            }
        }
        
        int[] decimalValues = new int[playerCount];
        
        for(int i = 0; i < playerCount; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                decimalValues[i]+= (playerHand[i,3 - j -1] * (2 ^ j));
            }
        }
        
        int largestNumber = decimalValues.Max();
        
        for(int i = 0; i < playerCount; i++)
        {
            if(decimalValues[i] == largestNumber)
            {
                Console.WriteLine(i+1);
            }
        }
        
        
    }
    
    static int ShiftBit(int currentHand, int deck, char shiftCode)
    {
        if(shiftCode == 'a')
        {
            return (currentHand | deck);
        }
        else if(shiftCode == 'b')
        {
            return (currentHand & deck);
        }
        else
        {
            return Convert.ToInt32(currentHand != deck);
        }
        
    }
}