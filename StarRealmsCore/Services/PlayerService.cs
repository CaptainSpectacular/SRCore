using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Data;
using StarRealmsCore.Models.Players;
using StarRealmsCore.Models.Games;

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
                    (pg, g) => new GameViewModel
                    {
                        Id = g.Id,
                        PlayerTurn = g.PlayerTurn
                    })
                    .ToList()
            })
            .ToList();
        }

        public PlayerViewModel GetPlayerDetails(string name)
        {
            return _context.Players.Where(player => player.Name == name)
                .Select(player => new PlayerViewModel
                {
                    Id = player.Id,
                    Name = player.Name,
                    Games = player.PlayerGames.Join(_context.Games,
                        pg => pg.GameId,
                        g => g.Id,
                        (pg, g) => new GameViewModel
                        {
                            Id = g.Id,
                            PlayerTurn = g.PlayerTurn
                        })
                        .ToList()
                })
                .SingleOrDefault();
        }

        public void CreatePlayer(PlayerCreateCommand command)
        {
            _context.Players.Add(command.ToPlayer());
            _context.SaveChanges();
        }

        public void CreatePlayerGame(PlayerGameCreateCommand command)
        {
            _context.PlayerGames.Add(command.ToPlayerGameChallenger());
            _context.PlayerGames.Add(command.ToPlayerGameTarget());
            _context.SaveChanges();
        }
    }
}
