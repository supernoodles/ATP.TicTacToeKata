namespace ATP.TicTacToeKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class TicTacToeShould
    {
        private TicTacToe _ticTacToe;

        [SetUp]
        public void SetUp()
        {
            _ticTacToe = new TicTacToe();
        }

        [Test]
        public void ReturnGameInProgress_GivenNoTurnsTaken()
        {
            _ticTacToe.IsInProgress().Should().BeTrue();
        }

        [Test]
        public void NotAllowOToTakeTurn_GivenNoTurns()
        {
            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerO, 0, 0);

            allowed.Should().BeFalse();
            message.Should().Be("It is X's go!");
        }

        [Test]
        public void AllowedXToTakeTurn_GivenNoTurns()
        {
            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);

            allowed.Should().BeTrue();
            message.Should().Be("All Good");
        }

        [Test]
        public void AllowOToTakeTurn_GivenXHasTakenTurn()
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerO, 0, 1);

            allowed.Should().BeTrue();
            message.Should().Be("All Good");
        }

        [Test]
        public void AllowXToTakeTurn_GivenOHasTakenTurn()
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 0, 1);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 2);

            allowed.Should().BeTrue();
            message.Should().Be("All Good");
        }

        [Test]
        public void NotAllowXToTakeTurn_GivenXHasTakenTurn()
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);
            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 1);

            allowed.Should().BeFalse();
            message.Should().Be("It is O's go!");
        }

        [Test]
        public void NotAllowOToTakeTurn_GivenOHasTakenTurn()
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);
            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 1);

            allowed.Should().BeFalse();
            message.Should().Be("It is O's go!");
        }

        [Test]
        public void NotAllowedRow0Column0_GivenRow0Column0Populated()
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);
            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerO, 0, 0);

            allowed.Should().BeFalse();
            message.Should().Be("Square already populated");
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        public void MakeXWinner_GivenThreeXsInRow(int xRow, int oRow)
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, xRow, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, oRow, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, xRow, 1);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, oRow, 1);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, xRow, 2);

            allowed.Should().BeTrue();
            message.Should().Be("X is the winner!");
        }

        [TestCase(0, 1, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(2, 0, 1)]
        public void MakeOWinner_GivenThreeOsInRow(int oRow, int xRow1, int xRow2)
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, xRow1, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, oRow, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, xRow1, 1);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, oRow, 1);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, xRow2, 0);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerO, oRow, 2);

            allowed.Should().BeTrue();
            message.Should().Be("O is the winner!");
        }

        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        public void MakeXWinner_GivenThreeXsInColumn(int xColumn, int oColumn)
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, xColumn);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 0, oColumn);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 1, xColumn);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 1, oColumn);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, 2, xColumn);

            allowed.Should().BeTrue();
            message.Should().Be("X is the winner!");
        }

        [TestCase(0, 1, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(2, 0, 1)]
        public void MakeOWinner_GivenThreeOsInColumn(int oColumn, int xColumn1, int xColumn2)
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, xColumn1);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 0, oColumn);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 1, xColumn1);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 1, oColumn);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, xColumn2);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerO, 2, oColumn);

            allowed.Should().BeTrue();
            message.Should().Be("O is the winner!");
        }
    }
}
