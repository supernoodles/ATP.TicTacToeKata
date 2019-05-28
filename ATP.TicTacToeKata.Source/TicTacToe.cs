namespace ATP.TicTacToeKata.Source
{
    public class TicTacToe
    {
        public bool IsInProgress()
        {
            return true;
        }

        public (bool allowed, string message) TakeTurn(string symbol, int row, int column)
        {
            if (symbol == "X")
            {
                return (true, "All Good");
            }

            return (false, "It is X's go!");
        }
    }
}