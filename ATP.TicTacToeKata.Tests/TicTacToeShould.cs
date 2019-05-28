﻿namespace ATP.TicTacToeKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class TicTacToeShould
    {
        [Test]
        public void ReturnGameInProgress_WhenNoTurnsTaken()
        {
            var ticTacToe = new TicTacToe();
            var inProgress = ticTacToe.IsInProgress();
            inProgress.Should().BeTrue();
        }
    }
}