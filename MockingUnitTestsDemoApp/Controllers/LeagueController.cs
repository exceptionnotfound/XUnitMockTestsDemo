using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;

namespace MockingUnitTestsDemoApp.Controllers
{
    public class LeagueController : Controller
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        public IActionResult Index()
        {
            var leagues = _leagueService.GetAll();
            return View(leagues);
        }
    }
}