using MockingUnitTestsDemoApp.Impl.Models;
using MockingUnitTestsDemoApp.Impl.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockingUnitTestsDemoApp.Impl.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        public Task<League> GetByID(int leagueID)
        {
            throw new NotImplementedException();
        }
    }
}
