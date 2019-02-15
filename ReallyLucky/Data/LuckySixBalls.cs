using ReallyLuckyBackend.Helpers;

namespace ReallyLuckyBackend.Data
{
    public class LuckySixBalls
    {
        public int LuckySixBallsId { get; set; }

        public int Number { get; set; }
        public Enums.Color Color { get; set; }

        public long RoundId { get; set; }
        public Round Round { get; set; }
    }
}