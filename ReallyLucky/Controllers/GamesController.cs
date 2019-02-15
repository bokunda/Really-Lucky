using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReallyLuckyBackend.Data;
using ReallyLuckyBackend.Services;

namespace ReallyLuckyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GameService gameService = new GameService();

        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            var games = gameService.GetAllGames();
            return games;
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = gameService.GetGame(id);
            return game;
        }
    }
}
