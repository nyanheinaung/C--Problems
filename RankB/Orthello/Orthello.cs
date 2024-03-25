using System;
class Program
{
    static void Main()
    {
        var line = Console.ReadLine();
        int gridSize = Int32.Parse(line);
        
        char[,] board = new char[gridSize,gridSize];
        
        for(int i = 0; i < gridSize; i++)
        {
            string boardRow = Console.ReadLine();
            
            for(int j = 0; j < gridSize; j++)
            {
                board[i,j] = boardRow[j];
            }
        }
        
        int possibleMoves = 0;
        
        for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                possibleMoves += CheckMove(board, i, j, gridSize);
            }
        }

        Console.WriteLine(possibleMoves);
    }
    
    
    static int CheckMove(char[,] board, int row, int column, int gridSize)
    {
        if(board[row,column] != '.')
        {
            return 0;
        }
        
        int[,] checkArray = {{0,1},{1,1},{1,0},{1,-1},{0,-1},{-1,-1},{-1,0},{-1,1}};
        
        for(int i = 0; i < 8; i++)
        {
            int rowCheck = row + checkArray[i,0];
            int columnCheck = column + checkArray[i,1];
            
            bool adjacentBlock = true;
            bool whiteFound = false;
            
            while(rowCheck < gridSize && columnCheck < gridSize && rowCheck >= 0 && columnCheck >= 0)
            {
                if(adjacentBlock && board[rowCheck, columnCheck] == 'B')
                {
                    break;
                }
                adjacentBlock = false;
                
                if(board[rowCheck, columnCheck] == 'W')
                {
                    whiteFound = true;
                }
                
                if(whiteFound && board[rowCheck, columnCheck] == 'B')
                {
                    return 1;
                }
                
                if(board[rowCheck, columnCheck] == '.')
                {
                    break;
                }
                
                
                
                rowCheck += checkArray[i,0];
                columnCheck += checkArray[i,1];

            }
        }

        return 0;
    }
}