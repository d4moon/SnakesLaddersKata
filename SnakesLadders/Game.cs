using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SnakesLadders
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

    public class Game
    {
        private IEnumerable<Player> players;
        private string status;

        public Game(IEnumerable<Player> players)
        {
            this.players = players;
        }

        public string GetStatus()
        {
            return status;
        }

        public void PlayUntilPlayerWins()
        {
            while (true)
            {
                foreach (var player in players)
                {
                    player.Move();

                    if (player.IsWinner())
                    {
                        status = player.Name + " wins";
                        return;
                    }
                }
            }
        }
    }
}