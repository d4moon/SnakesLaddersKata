﻿using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace SnakesLadders
{
    //the ability to move your token across the board using dice rolls.

    //Player roll a dice, 
    //Player move token the number of squares indicated by the dice roll 
    //Player win if they land on square 100.

    [TestFixture]
    public class PlayerShould
    {
        private readonly Player player1;
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
    }

    public class Player
    {
        public string Name { get; }
        private int tokenPosition;
        private readonly IDice dice;

        public Player(string name, IDice dice)
        {
            Name = name;
            tokenPosition = 1;
            this.dice = dice;
        }

        public void Move() => tokenPosition += dice.Roll();

        public int CurrentTokenPosition() => tokenPosition;
    }
}
