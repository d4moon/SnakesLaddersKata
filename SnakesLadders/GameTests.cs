using System;
using FluentAssertions;
using NUnit.Framework;

namespace SnakesLadders
{
    //the ability to move your token across the board using dice rolls.

    //Player roll a dice, 
    //Player move token the number of squares indicated by the dice roll 
    //Player win if they land on square 100.

    [TestFixture]
    public class GameTests
    {
        [Test]
        public void PlayerReceivesRandomDiceNumberGivenDiceRoll()
        {
            var game = new Game();

            var diceNumber = game.RollDice();

            diceNumber.Should().BeGreaterOrEqualTo(1).And.BeLessOrEqualTo(6);
        }
    }

    public class Game
    {
        private readonly Random randome = new Random();

        public int RollDice() => randome.Next(1, 6);
    }
}
