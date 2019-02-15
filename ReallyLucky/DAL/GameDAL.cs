using ReallyLuckyBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.DAL
{
    public class GameDAL
    {
        public List<Game> GetAllGames()
        {
            using (var db = new ReallyLuckyContext())
            {
                return db.Games.ToList();
            }
        }

        public Game GetGame(int id)
        {
            using (var db = new ReallyLuckyContext())
            {
                return db.Games.Where(g => g.GameId == id).FirstOrDefault();
            }
        }
    }
}
