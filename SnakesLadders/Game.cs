using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SnakesLadders
{
    [TestFixture]
    public class GameShould
    {
        //[Test]
        //public void RunGameUntilAplayerHasWonGivenPlayers()
        //{
        //    var fakeDice = new Mock<IDice>();
        //    fakeDice.Setup(d => d.Roll()).Returns(0);
        //    var player1 = new Player("player1", fakeDice.Object);
        //    var dice = new Dice();
        //    var player2 = new Player("player2", dice);
        //    var players = new List<Player> { player1, player2 };
        //    var game = new Game(players);

        //    game.Run();

        //    game.GetStatus().Should().Be("player2 wins");
        //}
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
            return null;
        }

        public void Run()
        {
            foreach (var player in players)
            {
                player.Move();

                if (player.CurrentTokenPosition() == 100)
                {
                    status = player.Name + " wins";
                    return;
                }
            }    
        }
    }
}