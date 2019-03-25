﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarRealmsCore.Data
{
    public class Game
    {
        public int Id { get; set; }
        public int PlayerTurn { get; set; }
        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
