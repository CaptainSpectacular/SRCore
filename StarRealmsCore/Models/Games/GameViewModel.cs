using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Models.Players;

namespace StarRealmsCore.Models.Games
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public int PlayerTurn { get; set; }
        public ICollection<PlayerViewModel> Players { get; set; }
    }
}
