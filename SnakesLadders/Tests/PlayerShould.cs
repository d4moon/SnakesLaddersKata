using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SnakesLadders.Tests
{
    [TestFixture]
    public class PlayerShould
    {
        private Player player1;
        private readonly Player player2;
        private readonly Mock<IDice> dice;

        public PlayerShould()
        {
            dice = new Mock<IDice>();

            player1 = new Player("player1", dice.Object);
            player2 = new Player("player2", dice.Object);
        }

        [Test]
        public void HaveTokenOnStartPositionGivenInitialised()
        {
            var players = new List<Player> { player1, player2 };

            foreach (var player in players)
            {
                player.CurrentTokenPosition().Should().Be(1);
            }
        }

        [Test]
        public void MoveTokenPositionGivenDiceRolledNumber()
        {
            dice.SetupSequence(d => d.Roll()).Returns(1).Returns(4);

            player1.Move();
            player1.Move();

            player1.CurrentTokenPosition().Should().Be(6);
        }

        [Test]
        public void NotMoveTokenPositionGiveDiceNumberExceedsWinningPosition()
        {
            dice.SetupSequence(d => d.Roll()).Returns(96).Returns(4);
            player1 = new Player("player1", dice.Object);

            player1.Move();
            player1.Move();

            player1.CurrentTokenPosition().Should().Be(97);
        }

        [Test]
        public void WinGivenTokenIsOnWinningPosition()
        {
            dice.SetupSequence(d => d.Roll()).Returns(96).Returns(3);
            player1 = new Player("player1", dice.Object);

            player1.Move();
            player1.Move();

            player1.IsWinner().Should().BeTrue();
        }
    }
}
