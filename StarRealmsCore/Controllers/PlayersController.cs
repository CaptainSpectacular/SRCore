using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Players;
using StarRealmsCore.Models.Games;

namespace StarRealmsCore.Controllers
{
    public class PlayersController : Controller
    {
        readonly PlayerService _playerService;
        readonly GameService _gameService;

        public PlayersController(PlayerService playerService, GameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            ICollection<PlayerViewModel> models = _playerService.GetPlayers();
            return Json(models);
        }

        public IActionResult Details(string name)
        {
            var model = _playerService.GetPlayerDetails(name);
            return Json(model);
        }

        [HttpPost]
        public IActionResult Create(PlayerCreateCommand cmd)
        {
            _playerService.CreatePlayer(cmd);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Route("Players/{ChallengerName}/NewGame")]
        public IActionResult CreateGame(PlayerGameCreateCommand cmd)
        {
            cmd = setCommandIds(cmd);
            _playerService.CreatePlayerGame(cmd);

            return RedirectToAction(nameof(Index));
        }

        private PlayerGameCreateCommand setCommandIds(PlayerGameCreateCommand cmd)
        {
            cmd.GameId = _gameService.CreateGame(new GameCreateCommand());
            cmd.ChallengerId = _playerService.GetPlayerId(cmd.ChallengerName);
            cmd.TargetId = _playerService.GetPlayerId(cmd.TargetName);

            return cmd;
        }
    }
}
