using ReallyLuckyBackend.DAL;
using ReallyLuckyBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.Services
{
    public class GameService
    {
        private GameDAL gameDAL = new GameDAL();

        public List<Game> GetAllGames()
        {
            return gameDAL.GetAllGames();
        }

        public Game GetGame(int id)
        {
            return gameDAL.GetGame(id);
        }
    }
}
