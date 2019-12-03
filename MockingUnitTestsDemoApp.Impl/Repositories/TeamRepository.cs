using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public Task<Team> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Team>> GetForLeague(int leagueID)
        {
            throw new NotImplementedException();
        }
    }
}
