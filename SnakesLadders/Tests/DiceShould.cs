using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace SnakesLadders.Tests
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

        [Test]
        public void GenerateDifferentNumbersGivenItIsRolledMultipleTimes()
        {
            var dice = new Dice();
            var diceNumbers = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                diceNumbers.Add(dice.Roll());
            }

            Assert.IsTrue(AssertNumbersAreDifferent(diceNumbers));
        }

        private static bool AssertNumbersAreDifferent(IReadOnlyCollection<int> randomNumbers)
        {
            var previousNumber = randomNumbers.First();

            foreach (var number in randomNumbers)
            {
                if (number != previousNumber)
                    return true;

                previousNumber = number;
            }

            return false;
        }
    }
}