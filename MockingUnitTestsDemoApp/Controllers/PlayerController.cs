using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;

namespace MockingUnitTestsDemoApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ILeagueService _leagueService;
        private readonly IPlayerService _playerService;

        public PlayerController(ILeagueService leagueService,
                                IPlayerService playerService)
        {
            _leagueService = leagueService;
            _playerService = playerService;
        }

        public IActionResult Index(int id)
        {
            try
            {
                var player = _playerService.GetByID(id);
                return View(player);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult League(int id)
        {
            if (!_leagueService.IsValid(id))
                return RedirectToAction("Error", "Home");

            var players = _playerService.GetForLeague(id);
            return View(players);
        }
    }
}