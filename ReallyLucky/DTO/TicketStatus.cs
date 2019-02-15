using ReallyLuckyBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.DTO
{
    public class TicketStatus
    {
        public int Id { get; set; }
        public Enums.TicketStatus Status { get; set; }
    }
}
