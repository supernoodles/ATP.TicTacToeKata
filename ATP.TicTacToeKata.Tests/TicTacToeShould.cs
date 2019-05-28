namespace ATP.TicTacToeKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class TicTacToeShould
    {
        [Test]
        public void ReturnGameInProgress_GivenNoTurnsTaken()
        {
            var ticTacToe = new TicTacToe();
            var inProgress = ticTacToe.IsInProgress();
            inProgress.Should().BeTrue();
        }

        [Test]
        public void NotAllowOToTakeTurn_GivenNoTurns()
        {
            var ticTacToe = new TicTacToe();

            var (allowed, message) = ticTacToe.TakeTurn("O", 0, 0);

            allowed.Should().BeFalse();
            message.Should().Be("It is X's go!");
        }
    }
}
