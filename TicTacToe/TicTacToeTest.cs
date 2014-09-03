using System;

namespace TicTacToeGame
{
    public class TicTacToeGame
    {
        public static void Main()
        {
            TicTacToe game = new TicTacToe();
            game.PrintBoard();
            game.Play();
        }
    }
}