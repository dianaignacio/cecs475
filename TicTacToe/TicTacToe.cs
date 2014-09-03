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
        }

        void GetPlayer2Move()
        {
            Console.WriteLine("Player 2's turn");
            int rowVal = 0;
            int columnVal = 0;
            rowVal = MoveCheck("Player 2: Enter row ( 0 <= row < 3: ", 0, 3);
            columnVal = MoveCheck("Player 2: Enter column ( 0 <= column < 3: ", 0, 3);
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

        void PlayMove(int[,] arr, int playerIndex)
        {
            PrintBoard();
            Console.WriteLine("Player {0}'s turn!", playerIndex + 1);
            //var move = playerMove();
            //board[move.Item1, move.Item2] = players[playerIndex];
        }
        
        public void Play()
        {
            bool endOfGame = false;
            while (!endOfGame)
            {
                GetPlayer1Move();
                PrintBoard();
                GetPlayer2Move();
            }
            PrintBoard();
            Console.WriteLine("Player has won!");
        }
        
    }   // end TicTacToe class
