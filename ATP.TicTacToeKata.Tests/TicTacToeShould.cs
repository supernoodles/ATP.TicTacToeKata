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
            var (allowed, message) = _ticTacToe.TakeTurn("O", 0, 0);

            allowed.Should().BeFalse();
            message.Should().Be("It is X's go!");
        }

        [Test]
        public void AllowedXToTakeTurn_GivenNoTurns()
        {
            var (allowed, message) = _ticTacToe.TakeTurn("X", 0, 0);

            allowed.Should().BeTrue();
            message.Should().Be("All Good");
        }
    }
}
