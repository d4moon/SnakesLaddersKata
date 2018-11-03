using System.Collections.Generic;

namespace SnakesLadders
{
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
            return status;
        }

        public void PlayUntilPlayerWins()
        {
            while (true)
            {
                foreach (var player in players)
                {
                    player.Move();

                    if (player.IsWinner())
                    {
                        status = player.Name + " wins";
                        return;
                    }
                }
            }
        }
    }
}