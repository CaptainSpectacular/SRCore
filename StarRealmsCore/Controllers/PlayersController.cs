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
        readonly PlayerService _service;

        public PlayersController(PlayerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ICollection<PlayerViewModel> models = _service.GetPlayers();
            return Json(models);
        }

        public IActionResult Details(string name)
        {
            var model = _service.GetPlayerDetails(name);
            return Json(model);
        }

        [HttpPost]
        public IActionResult Create(PlayerCreateCommand command)
        {
            _service.CreatePlayer(command);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [Route("Players/{ChallengerName}/NewGame")]
        public IActionResult CreateGame(PlayerGameCreateCommand pgCommand)
        {
            pgCommand = setCommandIds(pgCommand);
            _service.CreatePlayerGame(pgCommand);

            return RedirectToAction(nameof(Index));
        }

        private PlayerGameCreateCommand setCommandIds(PlayerGameCreateCommand pgCommand)
        {
            pgCommand.GameId = _service.CreateGame(new GameCreateCommand());
            pgCommand.ChallengerId = _service.GetPlayerDetails(pgCommand.ChallengerName).Id;
            pgCommand.TargetId = _service.GetPlayerDetails(pgCommand.TargetName).Id;

            return pgCommand;
        }
    }
}
