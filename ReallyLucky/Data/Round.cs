using System;
using System.Collections.Generic;

namespace ReallyLuckyBackend.Data
{    
    public class Round
    {
        public long RoundId { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public DateTime DateTimeEnded { get; set; }

        public ICollection<LuckySixBalls> LuckySixBalls { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}