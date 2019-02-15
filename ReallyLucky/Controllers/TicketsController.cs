using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReallyLuckyBackend.Data;
using ReallyLuckyBackend.Services;
using Newtonsoft.Json;
using ReallyLuckyBackend.Helpers;
using ReallyLuckyBackend.DTO;

namespace ReallyLuckyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private GameService gameService = new GameService();
        private TicketService ticketService = new TicketService();

        // GET api/tickets
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> Get()
        {
            var tickets = ticketService.GetAllTickets();
            return tickets;
        }

        // GET api/tickets/5
        [HttpGet("{id}")]
        public ActionResult<Ticket> Get(int id)
        {
            var ticket = ticketService.GetTicket(id);
            return ticket;
        }

        // GET api/tickets/add
        [HttpPost("add")]
        public ActionResult<long> Get(Ticket ticket)
        {
            return ticketService.CreateNewTicket(ticket);
        }

        [HttpGet("draw/{id}")]
        public ActionResult<Round> Draw(int id)
        {
            var round = ticketService.DrawRound(id);
            return round;
        }

        //[HttpGet("setStatus/{id}")]
        //public ActionResult<int> SetTicketStatus(long id, Enums.TicketStatus status)
        //{
        //    ticketService.SetTicketStatus(id, status);
        //    return Ok(true);
        //}

        // GET api/tickets/add
        [HttpPost("setstatus")]
        public ActionResult<int> SetTicketStatus(TicketStatus ticketStatus)
        {
            ticketService.SetTicketStatus(ticketStatus.Id, ticketStatus.Status);
            return Ok(true);
        }

        [HttpGet("getStatistics")]
        public ActionResult<Statistics> GetStatistics()
        {
            var statisticts = ticketService.GetStatistics();
            return statisticts;
        }
    }
}
