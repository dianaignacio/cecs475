//  Filename: TicTacToe.cs
//  Author: Diana Ignacio
//  Class: CECS 475
//  Lab: 1
//  Date Written: 9/4/2014
//  Description: Create class TicTacToe that will enable you to write a complete app
//                  to play the game of TicTacToe. The class contains a private 3x3
//                  rectangular array of integers. The constructor should initialize
//                  the empty board to all 0's. Allow two human players. Wherever the
//                  first player moves, place a 1 in a specific square, and place a 2
//                  wherever the second player moves. Each move must be to an empty
//                  square. After each move, determine whether the game has been won
//                  and whether it's a draw.
using System;
public class TicTacToe
    {
        private const int BOARDSIZE = 3; // size of the board
        private int[,] board = new int[BOARDSIZE,BOARDSIZE];// board representation
        int playCount = 0;

        /*
            PrintBoard() method prints out a 3x3 grid, as well as the 2D board
            array with values initialized to 0.
         */
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

        /*
            GetPlayer1Move() asks for player 1's move by row and column.
            If the square is between 0 < x <= 3 and the square is not
            occupied, then the move is valid and saved in the board array.
         */
        void GetPlayer1Move()
        {
            int rowVal = 0;
            int columnVal = 0;
            bool isNotOccupied = false;
            Console.WriteLine("\nPlayer 1's turn");
            while (!isNotOccupied)
            {
                rowVal = MoveCheck("Player 1: Enter row ( 0 <= row < 3: ", 0, 3);
                columnVal = MoveCheck("Player 1: Enter column ( 0 <= column < 3: ", 0, 3);
                if (((board[rowVal, columnVal] == 1) || board[rowVal, columnVal] == 2))
                {
                    Console.WriteLine("\nInvalid entry. Please retry.");
                }
                else
                {
                    isNotOccupied = true;
                }
            }
            board[rowVal, columnVal] = 1;
            PlayMove(board);            
        }

        /*
            GetPlayer2Move() asks for player 2's move by row and column.
            If the square is between 0 < x <= 3 and the square is not
            occupied, then the move is valid and saved in the board array.
         */
        void GetPlayer2Move()
        {
            int rowVal = 0;
            int columnVal = 0;
            bool isNotOccupied = false;
            Console.WriteLine("\nPlayer 2's turn");
            while (!isNotOccupied)
            {
                rowVal = MoveCheck("Player 2: Enter row ( 0 <= row < 3: ", 0, 3);
                columnVal = MoveCheck("Player 2: Enter column ( 0 <= column < 3: ", 0, 3);
                if (((board[rowVal, columnVal] == 1) || board[rowVal, columnVal] == 2))
                {
                    Console.WriteLine("\nInvalid entry. Please retry.");
                }
                else
                {
                    isNotOccupied = true;
                }
            }
            board[rowVal, columnVal] = 2;
            PlayMove(board);
        }

        /*
            MoveCheck parses user input if 0 < x <= 3.
            @param message is the game request to input move
            @param min is minimum possible input value
            @param max is maximum possible input value
         */
        int MoveCheck(string message, int min, int max)
        {
            Console.Write(message);
            string line = Console.ReadLine();
            int number;
            while (!(int.TryParse(line, out number) && min <= number && number < max))
            {
                Console.Write("\nInvalid entry. Please retry: ");
                line = Console.ReadLine();
            }
            return number;
        }

        /*
            PlayMove updates board with player moves
            @param arr is the 2D array of player moves
         */
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
            }
            Console.WriteLine("|_ _ _ _ _ _ _ _ _ _ _ _ _ _ _|");
        }

        /*
            player1win checks conditions of the 2D board array if the player 1
            has won. Method returns true if appropriate spaces of the board
            are equal to 1.
         */
        bool player1win()
        {
            bool p1win = false;
            if ((board[0, 0] == 1 && board[0, 1] == 1 && board[0, 2] == 1) || // 1st Horizontal win
             (board[1, 0] == 1 && board[1, 1] == 1 && board[1, 2] == 1) || // 2nd Horizontal win
             (board[2, 0] == 1 && board[2, 1] == 1 && board[2, 2] == 1) || // 3rd Horizontal win
             (board[0, 0] == 1 && board[1, 0] == 1 && board[2, 0] == 1) || // 1st Vertical win
             (board[0, 1] == 1 && board[1, 1] == 1 && board[2, 1] == 1) || // 2nd Vertical win
             (board[0, 2] == 1 && board[1, 2] == 1 && board[2, 2] == 1) || // 3rd Vertical win
             (board[0, 0] == 1 && board[1, 1] == 1 && board[2, 2] == 1) || // Left diagonal win   
             (board[0, 2] == 1 && board[1, 1] == 1 && board[2, 0] == 1))   // Right diagonal win
            {
                return (p1win = true);
            }
            return p1win;
        }

        /*
            player2win checks conditions of the 2D board array if the player 2
            has won. Method returns true if appropriate spaces of the board
            are equal to 2.
         */
        bool player2win()
        {
            bool p2win = false;
            if ((board[0, 0] == 2 && board[0, 1] == 2 && board[0, 2] == 2) || // 1st Horizontal win
                 (board[1, 0] == 2 && board[1, 1] == 2 && board[1, 2] == 2) || // 2nd Horizontal win
                 (board[2, 0] == 2 && board[2, 1] == 2 && board[2, 2] == 2) || // 3rd Horizontal win
                 (board[0, 0] == 2 && board[1, 0] == 2 && board[2, 0] == 2) || // 1st Vertical win
                 (board[0, 1] == 2 && board[1, 1] == 2 && board[2, 1] == 2) || // 2nd Vertical win
                 (board[0, 2] == 2 && board[1, 2] == 2 && board[2, 2] == 2) || // 3rd Vertical win
                 (board[0, 0] == 2 && board[1, 1] == 2 && board[2, 2] == 2) || // Left diagonal win   
                 (board[0, 2] == 2 && board[1, 1] == 2 && board[2, 0] == 2))   // Right diagonal win
                {
                    return (p2win = true);
                }
            return p2win;
        }

        /*
            Play() checks if the game has been won. If the game has not been won
            yet, the game continues.
         */
        public void Play()
        {
            while ((!player1win()) && (!player2win()))
            {
                GetPlayer1Move();
                if (player1win() == true)
                {
                    Console.WriteLine("Player 1 has won!");
                    break;
                }
                if ((playCount == BOARDSIZE + 1) &&
                ((player2win() == false) && (player1win() == false)))
                {
                    Console.WriteLine("Game is a draw.");
                    break;
                }
                GetPlayer2Move();
                if (player2win() == true)
                {
                    Console.WriteLine("Player 2 has won!");
                    break;
                }
                if ((playCount == BOARDSIZE + 1) &&
                ((player2win() == false) && (player1win() == false)))
                {
                    Console.WriteLine("Game is a draw.");
                    break;
                }
                playCount++;
            }
        }        
    }   // end TicTacToe class
