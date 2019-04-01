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
        [Route("Players/{PlayerName}/NewGame")]
        public IActionResult CreateGame(PlayerGameCreateCommand pgCommand)
        {
            int gameId = _service.CreateGame(new GameCreateCommand());
            int playerId = _service.GetPlayerDetails(pgCommand.PlayerName).Id;
            pgCommand.GameId = gameId;
            pgCommand.PlayerId = playerId;
            _service.CreatePlayerGame(pgCommand);
            return RedirectToAction(nameof(Index));
        }
    }
}
