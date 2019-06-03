﻿namespace ATP.TicTacToeKata.Source
{
    public class TicTacToe
    {
        public const string PlayerX = "X";
        public const string PlayerO = "O";

        private string _nextSymbol = PlayerX;

        private readonly string[,] _board = new string[3, 3];

        public bool IsInProgress()
        {
            return true;
        }

        public (bool allowed, string message) TakeTurn(string symbol, int row, int column)
        {
            if (_nextSymbol != symbol)
            {
                return (false, $"It is {_nextSymbol}'s go!");
            }

            _nextSymbol = symbol == PlayerX ? PlayerO : PlayerX;
             
            return SetSquareContent(symbol, row, column);
        }

        private (bool populated, string symbol) GetSquareContent(int row, int column)
        {
            var square = _board[row, column];

            if (square == null)
            {
                return (false, null);
            }

            return (true, square);
        }

        private (bool allowed, string message) SetSquareContent(string symbol, int row, int column)
        {
            var squareContent = GetSquareContent(row, column);

            if (squareContent.populated)
            {
                return (false, "Square already populated");
            }

            _board[row, column] = symbol;
            return (true, "All Good");
        }

    }
}