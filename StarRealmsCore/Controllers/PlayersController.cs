using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarRealmsCore.Services;
using StarRealmsCore.Models.Players;

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

        [HttpPost]
        public IActionResult Create(PlayerCreateCommand command)
        {
            _service.CreatePlayer(command);

            return RedirectToAction(nameof(Index));
        }
    }
}
