using ReallyLuckyBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReallyLuckyBackend.Helpers
{
    public static class InsertData
    {
        public static void InsertGames()
        {            
            using (var db = new ReallyLuckyContext())
            {
                if (db.Games.Where(g => g.Name == "Lucky 6").Count() == 0)
                {
                    Game game = new Game
                    {
                        Name = "Lucky 6",
                        Description = "Lucky Six is a draw based game where numbers are drawn from the drum. It is founded on the concept of the classic draw game where person gets the chance to pick random numbers or even colours, and follow live draw every five minutes. Due to its vibrant design and top-notch backend infrastructure, Lucky Six soon became our customers’ favourite and a proven profit generator.",
                        ImgSrc = "img/lucky6.jpg"
                    };
                    db.Games.Add(game);
                    db.SaveChanges();
                }
            }
        }
    }
}
