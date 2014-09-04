using System;

public class TicTacToe
    {
        private const int BOARDSIZE = 3; // size of the board
        private int[,] board = new int[BOARDSIZE,BOARDSIZE];// board representation
        int playCount = 0;

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

        // PlayMove method updates board with player moves
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
