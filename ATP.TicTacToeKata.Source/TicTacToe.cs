namespace ATP.TicTacToeKata.Source
{
    using System.Linq;

    public class TicTacToe
    {
        public const string PlayerX = "X";
        public const string PlayerO = "O";

        private const int MaxTurns = 9;

        private string _nextSymbol = PlayerX;

        private readonly string[,] _board = new string[3, 3];

        private int _turnCounter;

        public bool IsInProgress { get; private set; }

        public TicTacToe()
        {
            IsInProgress = true;
        }

        public (bool allowed, string message) TakeTurn(string symbol, int row, int column)
        {
            if (!IsInProgress)
            {
                return (false, "Game over man");
            }

            if (SymbolIsUnexpected(symbol))
            {
                return (false, $"It is {_nextSymbol}'s go!");
            }

            ToggleNextSymbol(symbol);

            if (!SetSquareContent(symbol, row, column))
            {
                return (false, "Square already populated");
            }

            if (CheckForWinner(symbol))
            {
                IsInProgress = false;
                return (true, $"{symbol} is the winner!");
            }

            if (_turnCounter == MaxTurns)
            {
                IsInProgress = false;
                return (true, "Game drawn!");
            }

            return (true, "All Good");
        }

        private void ToggleNextSymbol(string currentSymbol) =>
            _nextSymbol = currentSymbol == PlayerX ? PlayerO : PlayerX;

        private bool SymbolIsUnexpected(string symbol) =>
            _nextSymbol != symbol;

        private bool SetSquareContent(string symbol, int row, int column)
        {
            var squareContent = _board[row, column];

            if (squareContent != null)
            {
                return false;
            }

            _board[row, column] = symbol;

            _turnCounter += 1;

            return true;
        }

        private bool CheckForWinner(string symbol) =>
            CheckForWinningRow(symbol) || CheckForWinningColumn(symbol) || CheckForWinningDiagonal(symbol);

        private bool CheckForWinningDiagonal(string symbol) =>
            _board[0, 0] == symbol && _board[1, 1] == symbol && _board[2, 2] == symbol ||
            _board[0, 2] == symbol && _board[1, 1] == symbol && _board[2, 0] == symbol;

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

        private bool CheckForWinningRowLinq(string symbol) =>
            Enumerable.Range(0, 3)
                .Select(row =>
                    Enumerable.Range(0, 3).Select(column => _board[row, column] == symbol).All(result => result))
                .Any(result => result);
    }
}