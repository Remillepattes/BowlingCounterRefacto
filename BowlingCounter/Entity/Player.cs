namespace BowlingCounter.Entity
{
    public class Player
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public List<Throw> Throws { get; set; }
    }
}
