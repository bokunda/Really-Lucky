using System.Collections.Generic;

namespace ReallyLuckyBackend.Data
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgSrc { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}