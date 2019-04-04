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

        public int CreateGame(GameCreateCommand command)
        {
            Game game = command.ToGame();
            _context.Games.Add(game);
            _context.SaveChanges();
            return game.Id;
        }

        public void DeleteGame(int id)
        {
            var game = _context.Games.Find(id);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public void CreatePlayerGames(GameCreateCommand cmd)
        {
            _context.PlayerGames.Add(cmd.ToPGChallenger());
            _context.PlayerGames.Add(cmd.ToPGTarget());
            _context.SaveChanges();
        }
    }
}
