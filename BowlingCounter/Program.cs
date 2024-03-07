using BowlingCounter.Services;
using static BowlingCounter.Entity.EGameState;

namespace BowlingRemi
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instance
            var myUI = UI.GetInstance();
            var gameManager = GameManager.GetInstance();

            myUI.DiplayWelcome();

            // Choice menu
            var choice = myUI.Write();

            if (int.TryParse(choice, out int intChoice) == false)
                throw new Exception("Choisi 1 ou 3 ducon");

            if (intChoice == (int)GameState.Start)
            {
                myUI.HowManyPlayers();
                gameManager.SetPlayer(myUI.WriteInt());

                for (int i = 0; i < gameManager.maxLap; i++)
                {
                    for (int player = 0; player < gameManager.GetPlayersCount(); player++)
                    {
                        var currentPlayer = gameManager.GetPlayer(player);

                        myUI.Play(player + 1);

                        myUI.FirstThrow();
                        int firstThrow = myUI.WriteInt();

                        int secondThrow = 0;

                        if (firstThrow == 10)
                            secondThrow = 0;
                        else
                        {
                            myUI.SecondThrow();
                            secondThrow = myUI.WriteInt();
                        }

                        currentPlayer.Throws.Add(new BowlingCounter.Entity.Throw() { Id = currentPlayer.Throws.Count, FirstThrow = firstThrow, SecondThrow = secondThrow });

                        gameManager.CalculateScore(currentPlayer);
                        myUI.GetTotalScore(currentPlayer);

                        myUI.GetThrowTable(currentPlayer);
                    }
                }
            }
            if (intChoice == (int)GameState.Exit)
            {
                // ????????????
            }
        }
    }
}
