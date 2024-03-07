using BowlingCounter.Entity;

namespace BowlingCounter.Services
{
    public class GameManager
    {
        private static GameManager instance { get; set; }
        public readonly int maxLap = 10;
        private List<Player> players = new();

        public static GameManager GetInstance()
        {
            if (instance == null)
                instance = new GameManager();

            return instance;
        }

        public int GetPlayersCount()
        {
            return players.Count;
        }

        public void SetPlayer(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player() { Throws = new() });
            }
        }

        public Player GetPlayer(int id)
        {
            var player = players.Where(e => e.Id == id).FirstOrDefault();
            if (player == null)
                throw new Exception("Player not found!");

            return player;
        }

        public void CalculateScore(Player player)
        {
            player.Score = 0;

            foreach (var @throw in player.Throws)
            {
                NormalThrow(player, @throw);

                if (IsAStrike(@throw))
                    Strike(player, @throw);
                else if (IsASpare(@throw))
                    Spare(player, @throw);
            }
        }

        public bool IsAStrike(Throw lastThrowLap)
        {
            return lastThrowLap.FirstThrow == 10;
        }

        public bool IsASpare(Throw lastThrowLap)
        {
            return lastThrowLap.FirstThrow + lastThrowLap.SecondThrow == 10;
        }

        public void NormalThrow(Player player, Throw @throw)
        {
            player.Score += @throw.FirstThrow + @throw.SecondThrow;
        }

        public void Strike(Player player, Throw @throw)
        {
            var nextThrow = GetNextThrow(player, @throw);
            player.Score += nextThrow.FirstThrow + nextThrow.SecondThrow;
        }

        public void Spare(Player player, Throw @throw)
        {
            var nextThrow = GetNextThrow(player, @throw);
            player.Score += nextThrow.FirstThrow;
        }

        public Throw GetNextThrow(Player player, Throw @throw)
        {
            var nextThrow = player.Throws.Where(e => e.Id == @throw.Id + 1).FirstOrDefault();

            // Vu que je connais pas les règles pour le dernier tir, je passe tout à 0, il faudrait ajouter une condition pour le dernier tir
            if (nextThrow == null)
            {
                // throw new Exception("Next Throw doesn't exist");
                return new Throw() { Id = @throw.Id + 1, FirstThrow = 0, SecondThrow = 0 };
            }

            return nextThrow;
        }

        public int GetTotalScoreByPlayerId(int id)
        {
            return GetPlayer(id).Score;
        }
    }
}
