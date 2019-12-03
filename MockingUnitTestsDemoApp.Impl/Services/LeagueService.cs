using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using MockingUnitTestsDemoApp.Impl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly ITeamRepository _teamRepo;

        public LeagueService(IPlayerRepository playerRepo,
                             ITeamRepository teamRepo)
        {
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
        }

        public async Task<List<Player>> GetAllPlayers(int leagueID)
        {
            List<Player> players = new List<Player>();

            var teams = await _teamRepo.GetForLeague(leagueID);

            foreach(var team in teams)
            {
                players.AddRange(await _playerRepo.GetForTeam(team.ID));
            }

            return players;
        }
    }
}
