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
            var squareContent = _board[row, column];

            if (squareContent != null)
            {
                return (false, "Square already populated");
            }

            _board[row, column] = symbol;

            if (CheckForWinningRow(symbol) || CheckForWinningColumn(symbol) || CheckForWinningDiagonal(symbol)) 
            {
                return (true, $"{symbol} is the winner!");
            }

            return (true, "All Good");
        }

        private bool CheckForWinningDiagonal(string symbol)
        {
            if (_board[0, 0] == symbol && _board[1, 1] == symbol && _board[2, 2] == symbol ||
                _board[0, 2] == symbol && _board[1, 1] == symbol && _board[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }

        private bool CheckForWinningColumn(string symbol)
        {
            for (var column = 0; column <= 2; column++)
            {
                if (_board[0, column] == symbol && _board[1, column] == symbol && _board[2, column] == symbol)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckForWinningRow(string symbol)
        {
            for (var row = 0; row <= 2; row++)
            {
                if (_board[row, 0] == symbol && _board[row, 1] == symbol && _board[row, 2] == symbol)
                {
                    return true;
                }
            }

            return false;
        }




    }
}