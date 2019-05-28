namespace ATP.TicTacToeKata.Source
{
    public class TicTacToe
    {

        private string _nextSymbol = "X";

        public bool IsInProgress()
        {
            return true;
        }

        public (bool allowed, string message) TakeTurn(string symbol, int row, int column)
        {
            if (_nextSymbol != symbol)
            {
                return (false, "It is X's go!");
            }

            _nextSymbol = symbol == "X" ? "O" : "X";

            return (true, "All Good");
        }
    }
}