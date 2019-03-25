using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;
using StarRealmsCore.Models.Players;

namespace StarRealmsCore.Services
{
    public class PlayerService
    {
        readonly AppDbContext _context;

        public PlayerService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<PlayerViewModel> GetPlayers()
        {
            return _context.Players.Select(player => new PlayerViewModel
            {
                Name = player.Name,
                Games = player.PlayerGames.Join(_context.Games,
                    pg => pg.GameId,
                    g => g.Id,
                    (pg, g) => new Models.Games.GameViewModel
                    {
                        Id = g.Id,
                        PlayerTurn = g.PlayerTurn + 1
                    })
                    .ToList()
            })
            .ToList();
        }

        public void CreatePlayer(PlayerCreateCommand command)
        {
            _context.Players.Add(command.ToPlayer());
            _context.SaveChanges();
        }
    }
}
