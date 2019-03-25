using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Models.Games;

namespace StarRealmsCore.Models.Players
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public ICollection<GameViewModel> Games { get; set; }
    }
}
