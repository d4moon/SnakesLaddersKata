using System;
using System.Collections.Generic;
using FluentAssertions;
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

        public PlayerShould()
        {
            player1 = new Player("player1");
            player2 = new Player("player2");
        }

        [Test]
        public void IsOnStartPositionGivenInitialised()
        {
            var players = new List<Player> { player1, player2 };

            foreach (var player in players)
            {
                player.CurrentPosition().Should().Be(0);
            }
        }

        [Test]
        public void ReceiveRandomDiceNumberGivenDiceRoll()
        {
            var diceNumber = player1.RollDice();

            diceNumber.Should()
                .BeGreaterOrEqualTo(1)
                .And
                .BeLessOrEqualTo(6);
        }

        [Test]
        public void MovePositionGivenNumberOfSquares()
        {
            player1.Move(1);
            player1.Move(4);

            player1.CurrentPosition().Should().Be(5);
        }
    }

    public class Player
    {
        public string Name { get; }
        private int position;
        private readonly Random randome = new Random();

        public Player(string name)
        {
            Name = name;
        }

        public int RollDice() => randome.Next(1, 6);

        public void Move(int numberOfSquares) => position += numberOfSquares;

        public int CurrentPosition() => position;
    }
}
