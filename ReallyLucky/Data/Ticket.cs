using ReallyLuckyBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.Data
{
    public class Ticket
    {
        public long TicketId { get; set; }

        public ICollection<LuckySixBalls> LuckySixBalls { get; set; }
        public DateTime DateCreated { get; set; }
        public Enums.TicketStatus Status { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
