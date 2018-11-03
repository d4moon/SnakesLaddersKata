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
        [Test]
        public void ReceiveRandomDiceNumberGivenDiceRoll()
        {
            var player = new Player("player1");

            var diceNumber = player.RollDice();

            diceNumber.Should().BeGreaterOrEqualTo(1).And.BeLessOrEqualTo(6);
        }

        [Test]
        public void IsOnStartPositionGivenInitialised()
        {
            var players = new List<Player> { new Player("player1"), new Player("player2") };

            foreach (var player in players)
            {
                player.Position.Should().Be(0);
            }
        }
    }

    public class Player
    {
        public string Name{ get; }
        public int Position { get; }
        private readonly Random randome = new Random();

        public Player(string name)
        {
            Name = name;
            Position = 0;
        }

        public int RollDice() => randome.Next(1, 6);
    }
}
