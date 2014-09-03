using System;

public class TicTacToe
    {
        private const int BOARDSIZE = 3; // size of the board
        private int[,] board = new int[BOARDSIZE,BOARDSIZE];// board representation
        private int[] players = { 1, 2 };

        public void PrintBoard()
        {
                for (int x = 0; x < 3; x++)
                {
                     Console.WriteLine(" _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                     Console.WriteLine("|         |         |         |");
                     for (int y = 0; y < 3; y++)
                     {
                        Console.Write("|         ", board[x, y]);
                     }
                     Console.WriteLine("|");
                }
                  Console.WriteLine("|_ _ _ _ _ _ _ _ _ _ _ _ _ _ _|");
        }
                
        void GetPlayer1Move()
        {
            Console.WriteLine("Player 1's turn");
            int rowVal = 0;
            int columnVal = 0;
            rowVal = MoveCheck("Player 1: Enter row ( 0 <= row < 3: ", 0, 3);
            columnVal = MoveCheck("Player 1: Enter column ( 0 <= column < 3: ", 0, 3);
            board[rowVal, columnVal] = 1;
            PlayMove(board);
        }

        void GetPlayer2Move()
        {
            Console.WriteLine("Player 2's turn");
            int rowVal = 0;
            int columnVal = 0;
            rowVal = MoveCheck("Player 2: Enter row ( 0 <= row < 3: ", 0, 3);
            columnVal = MoveCheck("Player 2: Enter column ( 0 <= column < 3: ", 0, 3);
            board[rowVal, columnVal] = 2;
            PlayMove(board);
        }
        
        int MoveCheck(string message, int min, int max)
        {
            Console.Write(message);
            string line = Console.ReadLine();
            int number;
            while (!(int.TryParse(line, out number) && min <= number && number < max))
            {
                Console.Write("\nInvalid entry. Please retry : ");
                line = Console.ReadLine();
            }
            return number;
        }

        void PlayMove(int[,] arr)
        {
            for (int x = 0; x < BOARDSIZE; x++)
            {
                Console.WriteLine(" _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
                Console.WriteLine("|         |         |         |");
                for (int y = 0; y < BOARDSIZE; y++)
                {
                    if (board[x, y] == 0)
                    {
                        Console.Write("|         ", board[x, y]);
                    }
                    else
                    {
                        Console.Write("|    {0}    ", board[x, y]);
                    }
                }
                Console.WriteLine("|");
            }  // End for-loop
            Console.WriteLine("|_ _ _ _ _ _ _ _ _ _ _ _ _ _ _|");
        }
        
        public void Play()
        {
            bool endOfGame = false;
            while (!endOfGame)
            {
                GetPlayer1Move();
                GetPlayer2Move();
            }
            PrintBoard();
            Console.WriteLine("Player has won!");
        }
        
    }   // end TicTacToe class
