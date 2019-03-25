using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarRealmsCore.Models.Games;
using StarRealmsCore.Data;

namespace StarRealmsCore.Services
{
    public class GameService
    {
        readonly AppDbContext _context;

        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<GameViewModel> GetGames()
        {
            return _context.Games.Select(game => new GameViewModel
            {
                Id = game.Id,
                PlayerTurn = game.PlayerTurn,
                Players = game.PlayerGames.Join(_context.Players,
                    pg => pg.PlayerId,
                    p => p.Id,
                    (pg, p) => new Models.Players.PlayerViewModel
                    {
                        Name = p.Name,
                    })
                    .ToList()
            })
            .ToList();
        }

        public void CreateGame(GameCreateCommand command)
        {
            _context.Games.Add(command.ToGame());
            _context.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            var game = _context.Games.Find(id);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }
    }
}
