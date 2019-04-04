using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Games;

namespace StarRealmsCore.Controllers
{
    public class GamesController : Controller
    {
        readonly GameService _gameService;
        readonly DeckService _deckService;

        public GamesController(GameService gameService, DeckService deckService)
        {
            _gameService = gameService;
            _deckService = deckService;
        }

        public IActionResult Index()
        {
            var models = _gameService.GetGames();
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            return Json(models);
        }

        [HttpPost]
        [Route("Players/{ChallengerName}/NewGame")]
        public IActionResult Create(GameCreateCommand cmd)
        {

            cmd.Id = _gameService.CreateGame(cmd);
            _gameService.CreatePlayerGames(cmd);
            _deckService.CreateDeck(cmd.ToChallengerDeck());
            _deckService.CreateDeck(cmd.ToTargetDeck());
            
            return RedirectToAction(nameof(Index));
        }
    }
}
