using System;
using System.Runtime.Remoting.Messaging;

namespace ATP.TicTacToeKata.Source
{
    public class TicTacToe
    {
        public enum Player
        {
            X,
            O
        }

        private Player _nextSymbol = Player.X;

        private Player?[,] _board = new Player?[3, 3];

        public bool IsInProgress()
        {
            return true;
        }

        public (bool allowed, string message) TakeTurn(Player symbol, int row, int column)
        {
            if (_nextSymbol != symbol)
            {
                return (false, $"It is {_nextSymbol}'s go!");
            }

            _nextSymbol = symbol == Player.X ? Player.O : Player.X;

            return SetSquareContent(symbol, row, column);
        }

        public (bool populated, Player? symbol) GetSquareContent(int row, int column)
        {
            var square = _board[row, column];

            if (square == null)
            {
                return (false, null);
            }

            return (true, square);
        }

        public (bool allowed, string message) SetSquareContent(Player symbol, int row, int column)
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