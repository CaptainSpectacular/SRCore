using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;

namespace StarRealmsCore.Models.Players
{
    public class PlayerCreateCommand
    {
        public string Name { get; set; }

        public Player ToPlayer()
        {
            return new Player
            {
                Name = Name
            };
        }
    }
}
