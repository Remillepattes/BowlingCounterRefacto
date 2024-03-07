using BowlingCounter.Entity;

namespace BowlingCounter.Services
{
    public class UI
    {
        private static UI instance { get; set; }

        public static UI GetInstance()
        {
            if (instance == null)
                instance = new UI();

            return instance;
        }

        public void DiplayWelcome()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*** Welcome to the Bowling Counter ***");
            Console.WriteLine("**************************************");
            Console.WriteLine("\r\n");

            Console.WriteLine("MENU : ");
            Console.WriteLine("1- Start a new game");
            Console.WriteLine("3- Exit");
        }

        public void HowManyPlayers()
        {
            Console.Write("Enter number of players: ");
        }

        public void Play(int player)
        {
            Console.WriteLine($"Player {player}");
        }

        public void FirstThrow()
        {
            Console.WriteLine("Enter first throw: ");
        }

        public void SecondThrow()
        {
            Console.WriteLine("Enter second throw: ");
        }

        public void GetThrowTable(Player player)
        {
            Console.WriteLine("Throws:");
            foreach (var @throw in player.Throws)
                Console.Write("| " + @throw.FirstThrow + " " + @throw.SecondThrow + " ");
            Console.WriteLine("|");
        }

        public void GetTotalScore(Player player)
        {
            Console.WriteLine("Total score: " + player.Score);
        }

        public int WriteInt()
        {
            int.TryParse(Console.ReadLine(), out int result);
            return result;
        }

        public string? Write()
        {
            return Console.ReadLine();
        }
    }
}
