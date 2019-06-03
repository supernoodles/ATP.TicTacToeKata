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

        [Test]
        public void MakeXWinner_GivenThreeXsInTopRow()
        {
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 1, 0);
            _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 1);
            _ticTacToe.TakeTurn(TicTacToe.PlayerO, 1, 1);

            var (allowed, message) = _ticTacToe.TakeTurn(TicTacToe.PlayerX, 0, 2);

            allowed.Should().BeTrue();
            message.Should().Be("X is the winner!");
        }
    }
}
