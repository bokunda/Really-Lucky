using ReallyLuckyBackend.DAL;
using ReallyLuckyBackend.Data;
using ReallyLuckyBackend.DTO;
using ReallyLuckyBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.Services
{
    public class TicketService
    {
        private TicketDAL ticketDAL = new TicketDAL();

        public long CreateNewTicket(Ticket ticket)
        {
            return ticketDAL.CreateNewTicket(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return ticketDAL.GetAllTickets();
        }

        public Ticket GetTicket(long id)
        {
            return ticketDAL.GetTicket(id);
        }

        public Round DrawRound(int gameId)
        {
            return ticketDAL.DrawRound(gameId);
        }

        public void SetTicketStatus(long id, Enums.TicketStatus status)
        {
            ticketDAL.SetTicketStatus(id, status);            
        }

        public Statistics GetStatistics()
        {
            return ticketDAL.GetStatistics();
        }
    }
}
