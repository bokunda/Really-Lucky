using ReallyLuckyBackend.Data;
using ReallyLuckyBackend.DTO;
using ReallyLuckyBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.DAL
{
    public class TicketDAL
    {
        public long CreateNewTicket(Ticket ticket)
        {
            using (var db = new ReallyLuckyContext())
            {
                ticket.DateCreated = DateTime.UtcNow;
                db.Tickets.Add(ticket);
                db.SaveChanges();

                return ticket.TicketId;
            }
        }

        public List<Ticket> GetAllTickets()
        {
            using (var db = new ReallyLuckyContext())
            {
                return db.Tickets.ToList();                
            }            
        }

        public Ticket GetTicket(long id)
        {
            using (var db = new ReallyLuckyContext())
            {
                return db.Tickets.Where(t => t.TicketId == id).FirstOrDefault();
            }
        }

        public Round DrawRound(int gameId)
        {
            using (var db = new ReallyLuckyContext())
            {  
                var round = new Round { GameId = gameId, DateTimeStarted = DateTime.UtcNow, DateTimeEnded = DateTime.UtcNow };
                var selectedGame = db.Games.Where(g => g.GameId == gameId).FirstOrDefault();

                if(selectedGame.Name == "Lucky 6")
                {                    
                    round.LuckySixBalls = new List<LuckySixBalls>();
                    // use const instead 20
                    for (int i = 0; i < 20; i++)
                    {
                        Random r = new Random();
                        var num = r.Next(48);
                        while(round.LuckySixBalls.Where(n => n.Number == num).Count() > 0)
                        {
                            num = r.Next(48);
                        }
                        round.LuckySixBalls.Add(new LuckySixBalls { Color = Enums.Color.BLACK, Number = num, RoundId = round.RoundId });
                    }

                    db.Rounds.Add(round);
                    db.SaveChanges();
                }

                return round;
            }
        }

        public void SetTicketStatus(long id, Enums.TicketStatus status)
        {
            using (var db = new ReallyLuckyContext())
            {
                var ticket = db.Tickets.Where(t => t.TicketId == id).FirstOrDefault();
                ticket.Status = status;
                db.Tickets.Attach(ticket);
                db.Entry(ticket).Property(p => p.Status).IsModified = true;
                db.SaveChanges();
            }
        }

        public Statistics GetStatistics()
        {
            using (var db = new ReallyLuckyContext())
            {
                Statistics statistics = new Statistics();
                statistics.Tickets = db.Tickets.Count();
                statistics.Winners = db.Tickets.Where(x => x.Status == Enums.TicketStatus.WIN).Count();
                return statistics;
            }
        }
    }
}
