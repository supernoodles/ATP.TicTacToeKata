namespace ATP.TicTacToeKata.Source
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

        private (bool allowed, string message) SetSquareContent(string symbol, int row, int column)
        {
            var squareContent = _board[row, column]; //GetSquareContent(row, column);

            if (squareContent != null)
            {
                return (false, "Square already populated");
            }

            _board[row, column] = symbol;

            if (CheckForWinningTopRow(symbol) || CheckForWinningMiddleRow(symbol))
            {
                return (true, $"{symbol} is the winner!");
            }

            return (true, "All Good");
        }

        private bool CheckForWinningTopRow(string player)
        {
            return _board[0, 0] == player && _board[0, 1] == player && _board[0, 2] == player;
        }
        private bool CheckForWinningMiddleRow(string symbol)
        {
            return _board[1, 0] == symbol && _board[1, 1] == symbol && _board[1, 2] == symbol;
        }


    }
}