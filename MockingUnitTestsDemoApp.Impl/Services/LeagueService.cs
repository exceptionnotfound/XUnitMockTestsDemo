using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepo;

        public LeagueService(ILeagueRepository leagueRepo)
        {
            _leagueRepo = leagueRepo;
        }

        public bool IsValid(int id)
        {
            return _leagueRepo.IsValid(id);
        }

        public List<League> GetAll()
        {
            return _leagueRepo.GetAll();
        }
    }
}
