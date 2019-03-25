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
        readonly GameService _service;

        public GamesController(GameService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var models = _service.GetGames();
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            return Json(models);
        }

        [HttpPost]
        public IActionResult Create(GameCreateCommand command)
        {

            _service.CreateGame(command);
            return RedirectToAction(nameof(Index));
        }
    }
}