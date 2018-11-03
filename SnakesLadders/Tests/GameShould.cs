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
        public void RunGameUntilAplayerHasWonGivenPlayers()
        {
            var fakeDice = new Mock<IDice>();
            fakeDice.Setup(d => d.Roll()).Returns(0);
            var player1 = new Player("player1", fakeDice.Object);
            var dice = new Dice();
            var player2 = new Player("player2", dice);
            var players = new List<Player> { player1, player2 };
            var game = new Game(players);

            game.PlayUntilPlayerWins();

            game.GetStatus().Should().Be("player2 wins");
        }
    }
}