using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;

namespace StarRealmsCore.Models.Games
{
    public class GameCreateCommand
    {
        public int Id { get; set; }
        public int PlayerTurn { get; set; }

        public Game ToGame()
        {
            Random rnd = new Random();
            return new Game
            {
                Id = Id,
                PlayerTurn = rnd.Next(1, 3) 
            };
        }
    }
}
