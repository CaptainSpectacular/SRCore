using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class Player
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public string Name { get; set; }
    }
}
