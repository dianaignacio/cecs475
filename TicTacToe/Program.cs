using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToe
    {
        private const int BOARDSIZE = 3; // size of the board
        private int[,] board = new int[,] { { }, { }, { }, 
                                            { }, { }, { },
                                            { }, { }, { } };// board representation

        public int this[int row, int column]
        {
            get { return board[row, column]; }
            set { board[row, column] = value; }
        }

        internal void PrintBoard()
        {
            for (int y = 0; y < board.Length; ++y)
            {
                for (int x = 0; x < board.Length; ++x)
                {
                    Console.Write(board[y, x]);
                    if (x < board.Length-1)
                    {
                        Console.Write('|');
                    }
                }
                Console.Write('\n');
            }
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

        internal void Play()
        {
            GetPlayer1Move();
            GetPlayer2Move();
        }
        
    }   // end TicTacToe class

    public class TicTacToeGame
    {
        static void Main()
        {
            TicTacToe game = new TicTacToe();
            game.PrintBoard();
            game.Play();
        }
    }
}
