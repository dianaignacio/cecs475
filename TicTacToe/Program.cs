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
        private int[,] board = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, 
                                            { 1, 0 }, { 1, 1 }, { 1, 2 } ,
                                            { 2, 0 }, { 2, 1 }, { 2, 2 } };// board representation
        internal void PrintBoard()
        {
            for (int i = 0; i < 12; i++)
            {
                if (i % 4 == 0) 
                {
                    Console.WriteLine(" ----------------------- ");
                }
                else
                {
                    Console.WriteLine("|       |       |       |");}
                }
            Console.WriteLine(" ----------------------- ");
        }

        void GetPlayer1Move()
        {
            Console.WriteLine("Player 1's turn");
            Console.Write("Player 1: Enter row ( 0 <= row < 3: ");
            string rowVal = Console.ReadLine();
            Console.Write("Player 1: Enter column ( 0 <= row < 3: ");
            string columnVal = Console.ReadLine();
        }

        void GetPlayer2Move()
        {
            Console.WriteLine("Player 2's turn");
            Console.Write("Player 2: Enter row ( 0 <= row < 3: ");
            string rowVal = Console.ReadLine();
            Console.Write("Player 2: Enter column ( 0 <= row < 3: ");
            string columnVal = Console.ReadLine();
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
