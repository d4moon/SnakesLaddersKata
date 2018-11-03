namespace SnakesLadders
{
    public class Player
    {
        private const int WinningPosition = 100;
        private int tokenPosition;
        private readonly IDice dice;

        public string Name { get; }

        public Player(string name, IDice dice)
        {
            Name = name;
            tokenPosition = 1;
            this.dice = dice;
        }

        public void Move()
        {
            var diceNumber = dice.Roll();

            if (tokenPosition + diceNumber <= WinningPosition)
                tokenPosition += diceNumber;
        } 

        public int CurrentTokenPosition() => tokenPosition;

        public bool IsWinner() => CurrentTokenPosition() == WinningPosition;
    }
}