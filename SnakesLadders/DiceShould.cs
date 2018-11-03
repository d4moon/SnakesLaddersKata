using FluentAssertions;
using NUnit.Framework;

namespace SnakesLadders
{
    [TestFixture]
    public class DiceShould
    {
        [Test]
        public void GenerateRandomNumberBetweenOneAndSixInclusiveGivenItIsRolled()
        {
            var dice = new Dice();

            var diceNumber = dice.Roll();

            diceNumber.Should()
                .BeGreaterOrEqualTo(1)
                .And
                .BeLessOrEqualTo(6);
        }
    }
}