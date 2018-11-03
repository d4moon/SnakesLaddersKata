using System;

namespace SnakesLadders
{
    public class Dice : IDice
    {
        private readonly Random randome = new Random();

        public int Roll() => randome.Next(1, 6);
    }

    public interface IDice
    {
        int Roll();
    }
}