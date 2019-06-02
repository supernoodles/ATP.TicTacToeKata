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
            
            return (true, "All Good");
        }
    }
}