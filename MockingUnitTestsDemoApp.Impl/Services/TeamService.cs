using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepo;
        private readonly ILeagueRepository _leagueRepo;

        public TeamService(ITeamRepository teamRepo,
                           ILeagueRepository leagueRepo)
        {
            _teamRepo = teamRepo;
            _leagueRepo = leagueRepo;
        }

        public async Task<List<Team>> Search(TeamSearch search)
        {
            var isValidLeague = await _leagueRepo.IsValid(search.LeagueID);
            if (!isValidLeague)
                return new List<Team>();

            var allTeams = await _teamRepo.GetForLeague(search.LeagueID);

            if(search.Direction == Enums.SearchDateDirection.OlderThan)
                return allTeams.Where(x => x.FoundingDate <= search.FoundingDate).ToList();
            else return allTeams.Where(x => x.FoundingDate >= search.FoundingDate).ToList();
        }
    }
}
