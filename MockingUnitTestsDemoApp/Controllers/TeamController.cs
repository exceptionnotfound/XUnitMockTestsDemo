using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;

namespace MockingUnitTestsDemoApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            var teamSearch = new TeamSearch();
            return View(teamSearch);
        }

        [HttpPost]
        public IActionResult Search(TeamSearch search)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Search"); //Assume there is some manner of implementing PRG pattern here.
            }

            var results = _teamService.Search(search);

            if(!results.Any())
            {
                return RedirectToAction("Search");
            }
            else
            {
                search.Results = results;
                return View(search);
            }
        }
    }
}