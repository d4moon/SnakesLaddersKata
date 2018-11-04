using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SnakesLadders.Tests
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void RunUntilOnePlayerWins()
        {
            var fakeDice = new Mock<IDice>();
            fakeDice.Setup(d => d.Roll()).Returns(0);
            var fakePlayer = new Player("player1", fakeDice.Object);

            var realDice = new Dice();
            var player2 = new Player("player2", realDice);

            var players = new List<Player> { fakePlayer, player2 };
            var game = new Game(players);

            game.PlayUntilPlayerWins();

            game.GetStatus().Should().Be("player2 wins");
        }
    }
}